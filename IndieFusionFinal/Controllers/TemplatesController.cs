using IndieFusionFinal.Data;
using IndieFusionFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TemplatesController : Controller
{
    private readonly IndieFusionFinalContext _context;

    public TemplatesController(IndieFusionFinalContext context)
    {
        _context = context;
    }

    // Método para carregar um jogo pelo ID
    public IActionResult TemplateJogo(int id)
    {
        var game = _context.Game
        .Include(g => g.User) // Carrega o usuário vinculado ao jogo
        .Include(g => g.Classification)
        .Include(g => g.Genre)
        .Include(g => g.Genre2)
        .Include(g => g.Reviews) // Inclui as avaliações
     .ThenInclude(r => r.User) // Inclui o usuário que fez a avaliação
        .FirstOrDefault(g => g.Id == id);

        if (game == null)
        {
            return NotFound();
        }

        // Adicione um log para verificar se as avaliações estão sendo carregadas
        Console.WriteLine($"Número de comentários: {game.Reviews.Count}");

        return View(game);
    }

    // Método para filtrar jogos
    public IActionResult TemplateFiltro(string nomeJogo, int? Classification_Id, int? Genre_Id, int? Genre2_Id)
    {

        var jogos = _context.Game
                            .Include(g => g.Classification)
                            .Include(g => g.Genre)
                            .Include(g => g.Genre2)
                            .AsQueryable();

        // Obtém o nome do gênero para exibir na View
        var genre = _context.Genre.FirstOrDefault(g => g.Id == Genre_Id);
        ViewData["GenreName"] = genre?.Description ?? "Todos os jogos";
        ViewData["GenreImage"] = !string.IsNullOrEmpty(genre?.ImagePath)
                                ? genre.ImagePath
                                : "~/images/default-genre.png";


        // Aplicação dos filtros
        if (!string.IsNullOrEmpty(nomeJogo))
            jogos = jogos.Where(g => g.Title.Contains(nomeJogo));

        if (Classification_Id.HasValue && Classification_Id.Value > 0)
            jogos = jogos.Where(g => g.Classification_Id == Classification_Id.Value);

        if (Genre_Id.HasValue && Genre_Id.Value > 0)
            jogos = jogos.Where(g => g.Genre_Id == Genre_Id.Value);

        if (Genre2_Id.HasValue && Genre2_Id.Value > 0)
            jogos = jogos.Where(g => g.Genre2_Id == Genre2_Id.Value);

        // Popula os dropdowns mantendo a seleção atual
        ViewBag.Classification_Id = new SelectList(_context.Classification.ToList(), "Id", "Description", Classification_Id);
        ViewBag.Genre_Id = new SelectList(_context.Genre.ToList(), "Id", "Description", Genre_Id);
        ViewBag.Genre2_Id = new SelectList(_context.Genre.ToList(), "Id", "Description", Genre2_Id);

        // Passa os filtros para a ViewData para manter os valores selecionados
        ViewData["NomeJogo"] = nomeJogo;
        ViewData["ClassificationId"] = Classification_Id ?? 0;
        ViewData["GenreId"] = Genre_Id ?? 0;
        ViewData["Genre2Id"] = Genre2_Id ?? 0;

        return View(jogos.ToList());
    }

    // Método de filtro simplificado
    public IActionResult Filtro(string nomeJogo, int? Classification_Id, int? Genre_Id, int? Genre2_Id)
    {
        var jogos = _context.Game
                            .Include(g => g.Classification)
                            .Include(g => g.Genre)
                            .Include(g => g.Genre2)
                            .AsQueryable();

        if (!string.IsNullOrEmpty(nomeJogo))
            jogos = jogos.Where(g => g.Title.Contains(nomeJogo));

        if (Classification_Id.HasValue)
            jogos = jogos.Where(g => g.Classification_Id == Classification_Id.Value);

        if (Genre_Id.HasValue)
            jogos = jogos.Where(g => g.Genre_Id == Genre_Id.Value);

        if (Genre2_Id.HasValue)
            jogos = jogos.Where(g => g.Genre2_Id == Genre2_Id.Value);

        // Populando os dropdowns
        ViewBag.Classification_Id = new SelectList(_context.Classification.ToList(), "Id", "Description", Classification_Id);
        ViewBag.Genre_Id = new SelectList(_context.Genre.ToList(), "Id", "Description", Genre_Id);
        ViewBag.Genre2_Id = new SelectList(_context.Genre.ToList(), "Id", "Description", Genre2_Id);

        // Passando valores para ViewData para manter o estado do formulário
        ViewData["NomeJogo"] = nomeJogo;
        ViewData["ClassificationId"] = Classification_Id;
        ViewData["GenreId"] = Genre_Id;
        ViewData["Genre2Id"] = Genre2_Id;

        return View(jogos.ToList());
    }


    public async Task<IActionResult> TemplatePerfil(int? id)
    {
        var userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
        {
            return RedirectToAction("Login", "Home");
        }

        if (id == null)
        {
            id = userId;
        }

        var user = await _context.User.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        if (userId != id && userId != 1)
        {
            return Forbid();
        }

        // Preenche a ViewBag com os tipos de usuário válidos
        ViewBag.UserTp = new SelectList(await _context.UserType.ToListAsync(), "Id", "Description", user.UserTp);

        return View(user);
    }





    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TemplatePerfil(int? id,
     [Bind("Id,Name,NickName,Email,Password,BirthDate,UserTp,ImagePath")] User user,
     IFormFile? imageFile)
    {
        ModelState.Remove("Games");

        if (id != user.Id)
        {
            return NotFound();
        }

        if (_context.User.Any(u => u.NickName.ToLower() == user.NickName.ToLower() && u.Id != user.Id))
        {
            ModelState.AddModelError("NickName", "Este NickName já está em uso. Por favor, escolha outro.");
            return View(user);
        }

        if (!ModelState.IsValid)
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Erro: {error.ErrorMessage}");
            }
            ViewData["UserTp"] = new SelectList(_context.UserType, "Id", "Description", user.UserTp);
            return View(user);
        }

        try
        {
            var existingUser = await _context.User.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = user.Name;
            existingUser.NickName = user.NickName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.BirthDate = user.BirthDate;
            existingUser.UserTp = user.UserTp;

            if (imageFile != null && imageFile.Length > 0)
            {
                if (!string.IsNullOrEmpty(existingUser.ImagePath))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingUser.ImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                if (!Directory.Exists(imagesDirectory))
                {
                    Directory.CreateDirectory(imagesDirectory);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(imagesDirectory, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                existingUser.ImagePath = "/images/" + uniqueFileName;
            }
            else
            {
                Console.WriteLine("Nenhum arquivo foi enviado.");
            }

            _context.Entry(existingUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // Atualiza os dados do usuário na sessão
            HttpContext.Session.SetString("Username", existingUser.Name);
            HttpContext.Session.SetInt32("UserType", existingUser.UserTp);
            HttpContext.Session.SetString("ImagePath", existingUser.ImagePath);

            // Retorna para a página TemplatePerfil do usuário logado
            return RedirectToAction(nameof(TemplatePerfil), new { id = existingUser.Id });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar: {ex.Message}");
            return View(user);
        }
    }


    // Método auxiliar para checar existência do usuário
    private bool UserExists(int id)
    {
        return _context.User.Any(e => e.Id == id);
    }





    [HttpPost, ActionName("DeleteUser")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var userId = HttpContext.Session.GetInt32("UserId");

        if (id == null)
        {
            id = userId;
        }

        var user = await _context.User.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.User.Remove(user);
        await _context.SaveChangesAsync();

        if (userId == id)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        return RedirectToAction(nameof(Index));
    }


    // Processa o login
    [HttpPost]
    public IActionResult Login(string nickname, string password)
    {
        if (string.IsNullOrWhiteSpace(nickname) || string.IsNullOrWhiteSpace(password))
        {
            TempData["ErrorMessage"] = "Usuário e senha são obrigatórios!";
            return RedirectToAction("Index", "Home");
        }

        // Busca o usuário pelo nickname (usando ToLower para comparação case-insensitive)
        var user = _context.User.FirstOrDefault(u => u.NickName.ToLower() == nickname.ToLower());

        if (user != null && user.Password == password)
        {
            // Atualiza os dados na sessão
            HttpContext.Session.SetString("Username", user.Name);
            HttpContext.Session.SetString("NickName", user.NickName);
            HttpContext.Session.SetInt32("UserType", user.UserTp);
            HttpContext.Session.SetInt32("UserId", user.Id);

            // Define o caminho da imagem do usuário na sessão
            var imagePath = string.IsNullOrEmpty(user.ImagePath) ? "/IF/Img/Icones/PerfilWhite.png" : user.ImagePath;
            HttpContext.Session.SetString("ImagePath", imagePath);

            // Redireciona com base no tipo de usuário
            return user.UserTp switch
            {
                1 => RedirectToAction("Index", "Users"),
                2 => RedirectToAction("GameUser", "GameMakers"),
                _ => RedirectToAction("Index", "Home")
            };
        }
        else
        {
            TempData["ErrorMessage"] = "Usuário ou senha inválido!";
            return RedirectToAction("Index", "Home");
        }
    }

    // Página de Logout
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

    // Página de Cadastro
    public IActionResult Cadastro()
    {
        return View();
    }

    // Processa o Cadastro
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cadastro([Bind("Name,NickName,Email,Password,BirthDate")] User? user, IFormFile? imageFile)
    {
        // Garante que o usuário cadastrado seja do tipo "comum"
        user.UserTp = 3;

        if (_context.User.Any(u => u.NickName.ToLower() == user.NickName.ToLower()))
        {
            ModelState.AddModelError("NickName", "Este NickName já está em uso. Por favor, escolha outro.");
            return View(user);
        }

        if (ModelState.IsValid)
        {
            try
            {
                // Se um arquivo de imagem foi enviado, processa o upload
                if (imageFile != null && imageFile.Length > 0)
                {
                    var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    if (!Directory.Exists(imagesDirectory))
                    {
                        Directory.CreateDirectory(imagesDirectory);
                    }

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(imagesDirectory, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Atualiza o caminho da imagem no usuário
                    user.ImagePath = "/images/" + uniqueFileName;
                }

                _context.Add(user);
                await _context.SaveChangesAsync();

                TempData["ShowLoginModal"] = true;
                // Opcional: exibe mensagem ou redireciona para a página inicial
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar usuário: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao cadastrar o usuário. Tente novamente.");
            }
        }

        return View(user);
    }
}



