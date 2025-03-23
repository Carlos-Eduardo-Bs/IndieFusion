using IndieFusionFinal.Data;
using IndieFusionFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Indie.Controllers
{
    public class HomeController : Controller
    {
        private readonly IndieFusionFinalContext _context;

        public HomeController(IndieFusionFinalContext context)
        {
            _context = context;
        }

        // Página inicial
        public IActionResult Index(string nomeJogo, int? Genre_Id)
        {
            var username = HttpContext.Session.GetString("Username");
            var userType = HttpContext.Session.GetInt32("UserType");
            var imagePath = HttpContext.Session.GetString("ImagePath") ?? "/IF/Img/Icones/PerfilWhite.png";

            ViewBag.Username = username;
            ViewBag.UserType = userType;
            ViewBag.ImagePath = imagePath;

            // Consulta todos os jogos
            var jogos = _context.Game
                                .Include(g => g.Genre)
                                .ToList();  // Retorna todos os jogos

            // Se o nome do jogo for fornecido, filtra por título
            if (!string.IsNullOrEmpty(nomeJogo))
                jogos = jogos.Where(g => g.Title.Contains(nomeJogo)).ToList();

            // Se um gênero for selecionado, filtra por gênero
            if (Genre_Id.HasValue && Genre_Id.Value > 0)
                jogos = jogos.Where(g => g.Genre_Id == Genre_Id.Value).ToList();

            // Passa o nome do gênero selecionado (se houver)
            var genre = _context.Genre.FirstOrDefault(g => g.Id == Genre_Id);
            ViewData["GenreName"] = genre?.Description ?? "Todos os jogos";

            // Popula o dropdown com os gêneros
            var genresList = _context.Genre.Select(g => g.Description).ToList();
            ViewBag.Categories = genresList;  // Certifique-se de que ViewBag.Categories tenha uma lista válida

            ViewBag.Genre_Id = new SelectList(_context.Genre.ToList(), "Id", "Description", Genre_Id);

            return View(jogos);  // Retorna os jogos filtrados ou todos
        }







        // Obtém a lista de jogos para a página inicial (somente título, preço e imagem)
        private List<Game> GetGames()
        {
            return _context.Game.Select(game => new Game
            {
                Id = game.Id,
                Title = game.Title,
                price = game.price,
                ImagePath = game.ImagePath,
                AdditionalImage1 = game.AdditionalImage1,
                AdditionalImage2 = game.AdditionalImage2,
                AdditionalImage3 = game.AdditionalImage3,
                AdditionalImage4 = game.AdditionalImage4,
            }).ToList();
        }

        // Página de Loginp
        public IActionResult Login()
        {
            return View();
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
}