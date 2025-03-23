using IndieFusionAPI.Data;
using IndieFusionAPI.Models;
using IndieFusionAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndieFusionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : Controller
    {
        //campo de apoio DB
        private readonly IndieFusionFinalContextProject _context;

        public UserTypeController(IndieFusionFinalContextProject context)
        {
            _context = context;
        }


        //CRUD - Read
        [HttpGet]
        //[Authorize(Roles = "administrador,gerente,operacional")]

        public IActionResult GetUser()
        {
            try
            {
                var result = _context.UserType.ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro !! Exceção: {ex.Message}");
            }
        }


        //CRUD - Create
        [HttpPost]
        //[Authorize(Roles = "administrador,gerente")]
        public IActionResult PostUser([FromBody] UserType userType)
        {
            try
            {
                // Checa se o tipo de usuário já existe
                var listUser = _context.UserType.Where(x => x.Description == userType.Description).ToList();
                if (listUser.Count > 0)
                {
                    return BadRequest("Erro !! usuário ja existe !!");
                }
                _context.UserType.Add(userType);
                var result = _context.SaveChanges();
                if (result == 1)
                {
                    return Ok($"{userType.Description.ToUpper()} cadastrado com sucesso !!");
                }
                else
                {
                    return BadRequest("Erro !!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro !! Exceção: {ex.Message}");
            }
        }



        //CRUD - Update
        [HttpPut]
        //[Authorize(Roles = "administrador,gerente")]

        public IActionResult PutUser([FromBody] UserType userType)
        {
            try
            {
                _context.UserType.Update(userType);
                var result = _context.SaveChanges();
                if (result == 1)
                {
                    return Ok($"{userType.Description.ToUpper()} editado com sucesso !!");
                }
                else
                {
                    return BadRequest("Erro !!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro !! Exceção: {ex.Message}");
            }
        }

        //CRUD - Delete
        [HttpDelete("{id}")]
        //[Authorize(Roles = "administrador")]

        public IActionResult DeleteUser(int id)
        {
            try
            {
                UserType userType = _context.UserType.Find(id);
                if (userType != null)
                {
                    _context.UserType.Remove(userType);
                    var result = _context.SaveChanges();
                    if (result == 1)
                    {
                        return Ok($"{userType.Description.ToUpper()} eliminado com sucesso !!");
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
    }
}
