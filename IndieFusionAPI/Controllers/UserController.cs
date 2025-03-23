using IndieFusionAPI.Data;
using IndieFusionAPI.Models;
using IndieFusionAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndieFusionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class UserController : Controller
    {
        //campo de apoio DB
        private readonly IndieFusionFinalContextProject _context;

        //campo de apoio Token
        private readonly TokenService _service;


        public UserController(IndieFusionFinalContextProject context, TokenService service)
        {
            _context = context;
            _service = service;
        }

        //login
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = _context.Users.Where(x => x.NickName == userLogin.NickName).FirstOrDefault();
            if (user == null)
            {
                return NotFound("Usuário Inválido !!");
            }
            if (user.Password != userLogin.PasswordUser)
            {
                return BadRequest("Senha Inválida !!");
            }
            var token = _service.GerarToken(user);

            //zerar o password
            userLogin.PasswordUser = "";

            var result = new UserResponse()
            {
                User = user,
                Token = token
            };
            return Ok(result);
        }


        //filter
        [HttpGet("FilterByTypeUser")]
        public IActionResult FilterUser([FromQuery] string description)
        {
            try
            {
                var result = _context.Users
                                     .Include(u => u.UserType)
                                     .Where(u => u.UserType.Description.ToLower().Contains(description.ToLower()))
                                     .ToList();

                if (result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound($"Nenhum usuário encontrado para o tipo '{description}'.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro !! Exceção: {ex.Message}");
            }
        }




        //CRUD - Read
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var result = await _context.Users
                    .Include(u => u.UserType)  // Carrega a propriedade de navegação
                    .ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro !! Exceção: {ex.Message}");
            }
        }



        //CRUD - Create
        //[Authorize(Roles = "administrador,gerente")]

        [HttpPost("Create")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] User user, IFormFile? imageFile, [FromServices] IWebHostEnvironment env)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                string relativePath = null;

                // Verificar se o tipo de usuário existe
                var tipoUsuario = await _context.UserType.FirstOrDefaultAsync(u => u.Id == user.UserTp);
                if (tipoUsuario == null)
                {
                    return BadRequest(new { error = "Tipo de usuário não encontrado!" });
                }
                user.UserType = tipoUsuario;

                if (imageFile != null && imageFile.Length > 0)
                {
                    // Diretório onde a API salva a imagem
                    var apiImagesDirectory = Path.Combine(env.WebRootPath, "images");
                    if (!Directory.Exists(apiImagesDirectory))
                        Directory.CreateDirectory(apiImagesDirectory);

                    // Diretório do Web onde a imagem também será salva
                    var webImagesDirectory = @"C:\Users\carlos.ebserra\source\repos\Projeto Final\Projeto Final\IndieFusionFinal\wwwroot\images";
                    if (!Directory.Exists(webImagesDirectory))
                        Directory.CreateDirectory(webImagesDirectory);

                    // Gerar um nome único para o arquivo
                    var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                    var filePathAPI = Path.Combine(apiImagesDirectory, uniqueFileName);
                    var filePathWeb = Path.Combine(webImagesDirectory, uniqueFileName);

                    // Salvar na API
                    using (var stream = new FileStream(filePathAPI, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Copiar para o Web
                    System.IO.File.Copy(filePathAPI, filePathWeb, true);

                    // Definir o caminho relativo para acesso via navegador
                    relativePath = "images/" + uniqueFileName;  // Sem a barra inicial
                    user.ImagePath = relativePath;
                }

                // Salvar o usuário no banco de dados
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = $"{user.Name.ToUpper()} cadastrado com sucesso!",
                    imageUrl = relativePath
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Erro ao criar usuário: {ex.Message}" });
            }
        }


        [HttpPut("Edit")]
        [Consumes("multipart/form-data")] // Permite envio de arquivos no Swagger
        public async Task<IActionResult> Edit([FromForm] User user, IFormFile? imageFile, [FromServices] IWebHostEnvironment env)
        {
            if (user == null)
                return BadRequest("Dados inválidos.");

            try
            {
                // Buscar o usuário no banco pelo ID
                var existingUser = _context.Users.Find(user.IdUser);

                if (existingUser == null)
                    return NotFound("Usuário não encontrado.");

                // Atualizar os campos editáveis
                existingUser.Name = user.Name;
                existingUser.NickName = user.NickName;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.BirthDate = user.BirthDate;
                existingUser.UserTp = user.UserTp;

                string relativePath = existingUser.ImagePath; // Mantém a imagem antiga por padrão

                if (imageFile != null && imageFile.Length > 0)
                {
                    // Caminho da pasta de imagens na API
                    var apiImagesDirectory = Path.Combine(env.WebRootPath, "images");
                    if (!Directory.Exists(apiImagesDirectory))
                    {
                        Directory.CreateDirectory(apiImagesDirectory);
                    }

                    // Caminho na aplicação Web
                    var webImagesDirectory = @"C:\Users\carlos.ebserra\source\repos\Projeto Final\Projeto Final\IndieFusionFinal\wwwroot\images";
                    if (!Directory.Exists(webImagesDirectory))
                    {
                        Directory.CreateDirectory(webImagesDirectory);
                    }

                    // Remover imagem antiga se existir
                    if (!string.IsNullOrEmpty(existingUser.ImagePath))
                    {
                        var oldFilePathAPI = Path.Combine(apiImagesDirectory, Path.GetFileName(existingUser.ImagePath));
                        var oldFilePathWeb = Path.Combine(webImagesDirectory, Path.GetFileName(existingUser.ImagePath));

                        if (System.IO.File.Exists(oldFilePathAPI))
                            System.IO.File.Delete(oldFilePathAPI);

                        if (System.IO.File.Exists(oldFilePathWeb))
                            System.IO.File.Delete(oldFilePathWeb);
                    }

                    // Criar novo nome de arquivo
                    var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                    var filePathAPI = Path.Combine(apiImagesDirectory, uniqueFileName);
                    var filePathWeb = Path.Combine(webImagesDirectory, uniqueFileName);

                    // Salvar a nova imagem na API
                    using (var stream = new FileStream(filePathAPI, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Copiar a nova imagem para o Web
                    System.IO.File.Copy(filePathAPI, filePathWeb, true);

                    // Atualizar caminho da nova imagem no banco
                    relativePath = "/images/" + uniqueFileName;
                }

                existingUser.ImagePath = relativePath; // Atualiza o caminho da imagem
                await _context.SaveChangesAsync(); // Salva alterações no banco

                return Ok(new
                {
                    message = $"{existingUser.Name.ToUpper()} editado com sucesso!",
                    imageUrl = relativePath
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Erro ao atualizar usuário: {ex.InnerException?.Message ?? ex.Message}" });
            }
        }



        //CRUD - Delete
        [HttpDelete("{id}")]
        //[Authorize(Roles = "administrador")]

        public IActionResult DeleteUser(int id)
        {
            try
            {
                User user = _context.Users.Find(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    var result = _context.SaveChanges();
                    if (result == 1)
                    {
                        return Ok($"{user.Name.ToUpper()} eliminado com sucesso !!");
                    }
                    else
                    {
                        return BadRequest("Erro !!");
                    }

                }
                else
                {
                    return BadRequest("Erro !! usuario não exite !!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro !! Exceção: {ex.Message}");
            }
        }

        [HttpGet("GetUserTypes")]
        public IActionResult GetUserTypes()
        {
            try
            {
                var userTypes = _context.UserType
                    .Select(x => new { x.Id, x.Description })
                    .ToList();

                return Ok(userTypes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro !! Exceção: {ex.Message}");
            }
        }

    }
}
