using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndieFusionFinal.Data;
using IndieFusionFinal.Models;

namespace Indie.Controllers
{
    public class GameMakersController : Controller
    {
        private readonly IndieFusionFinalContext _context;

        public GameMakersController(IndieFusionFinalContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GameUser(string NomeJogo, int? Classification_Id, int? Genre_Id, int? Genre2_Id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var games = _context.Game
                                .Include(g => g.Classification)
                                .Include(g => g.Genre)
                                .Include(g => g.Genre2)
                                .Where(g => g.UserId == userId) // Filtra para pegar apenas os jogos do usuário logado
                                .AsQueryable();

            // Filtro por nome do jogo
            if (!string.IsNullOrEmpty(NomeJogo))
            {
                games = games.Where(g => g.Title.Contains(NomeJogo));
            }

            // Filtro por classificação
            if (Classification_Id.HasValue)
            {
                games = games.Where(g => g.Classification_Id == Classification_Id.Value);
            }

            // Filtro por gênero primário ou secundário
            if (Genre_Id.HasValue)
            {
                games = games.Where(g => g.Genre_Id == Genre_Id.Value || g.Genre2_Id == Genre_Id.Value);
            }

            // Filtro para o segundo gênero (primário ou secundário)
            if (Genre2_Id.HasValue)
            {
                games = games.Where(g => g.Genre2_Id == Genre2_Id.Value || g.Genre_Id == Genre2_Id.Value);
            }

            // Carregar as classificações e gêneros no ViewBag
            ViewBag.Classification_Id = new SelectList(await _context.Classification.ToListAsync(), "Id", "Description", Classification_Id);
            ViewBag.Genre_Id = new SelectList(await _context.Genre.ToListAsync(), "Id", "Description", Genre_Id);
            ViewBag.Genre2_Id = new SelectList(await _context.Genre.ToListAsync(), "Id", "Description", Genre2_Id);

            ViewData["NomeJogo"] = NomeJogo;

            return View(await games.ToListAsync());
        }

        public async Task<IActionResult> DetailsGame(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Classification)
                .Include(g => g.Genre)
                .Include(g => g.Genre2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult CreateGame()
        {
            ViewData["Classification_Id"] = new SelectList(_context.Classification, "Id", "Description");
            ViewData["Genre_Id"] = new SelectList(_context.Set<Genre>(), "Id", "Description");
            ViewData["Genre2_Id"] = new SelectList(_context.Set<Genre>(), "Id", "Description");
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGame(
     [Bind("Title,Producer,price,Classification_Id,Genre_Id,Genre2_Id")] Game game,
     IFormFile mainImageFile,       // Imagem Principal
     IFormFile bannerImageFile,     // Imagem do Banner
     List<IFormFile> additionalImageFiles, // Outras Imagens
     bool addSecondGenre)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário não autenticado.");
                return RedirectToAction("Login", "Home");
            }
            game.UserId = userId.Value;

            if (ModelState.IsValid)
            {
                try
                {
                    var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    if (!Directory.Exists(imagesDirectory))
                    {
                        Directory.CreateDirectory(imagesDirectory);
                    }

                    // Processa a imagem principal
                    if (mainImageFile != null)
                    {
                        var mainImageFileName = Guid.NewGuid().ToString() + Path.GetExtension(mainImageFile.FileName);
                        var mainImagePath = Path.Combine(imagesDirectory, mainImageFileName);
                        using (var stream = new FileStream(mainImagePath, FileMode.Create))
                        {
                            await mainImageFile.CopyToAsync(stream);
                        }
                        game.ImagePath = "/images/" + mainImageFileName;
                    }

                    // Processa a imagem do banner
                    if (bannerImageFile != null)
                    {
                        var bannerImageFileName = Guid.NewGuid().ToString() + Path.GetExtension(bannerImageFile.FileName);
                        var bannerImagePath = Path.Combine(imagesDirectory, bannerImageFileName);
                        using (var stream = new FileStream(bannerImagePath, FileMode.Create))
                        {
                            await bannerImageFile.CopyToAsync(stream);
                        }
                        game.BannerImage = "/images/" + bannerImageFileName;
                    }

                    // Processa as imagens adicionais (até 4) e atribui cada uma à sua propriedade
                    if (additionalImageFiles != null && additionalImageFiles.Count > 0)
                    {
                        int index = 0;
                        foreach (var file in additionalImageFiles.Take(4))
                        {
                            var addFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            var addFilePath = Path.Combine(imagesDirectory, addFileName);
                            using (var stream = new FileStream(addFilePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                            var relativePath = "/images/" + addFileName;
                            if (index == 0)
                                game.AdditionalImage1 = relativePath;
                            else if (index == 1)
                                game.AdditionalImage2 = relativePath;
                            else if (index == 2)
                                game.AdditionalImage3 = relativePath;
                            else if (index == 3)
                                game.AdditionalImage4 = relativePath;
                            index++;
                        }
                    }

                    _context.Add(game);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(GameUser));
                }
                catch (Exception ex)
                {
                    var innerMessage = ex.InnerException != null ? ex.InnerException.Message : "";
                    Console.WriteLine($"Erro ao criar jogo: {ex.Message} {innerMessage}");
                    ModelState.AddModelError("", $"Erro ao criar jogo: {ex.Message} {innerMessage}");
                }
            }

            ViewData["Classification_Id"] = new SelectList(_context.Classification, "Id", "Description", game.Classification_Id);
            ViewData["Genre_Id"] = new SelectList(_context.Genre, "Id", "Description", game.Genre_Id);
            ViewData["Genre2_Id"] = new SelectList(_context.Genre, "Id", "Description", game.Genre2_Id);
            return View(game);
        }


        // GET: Games/EditGame/5
        public async Task<IActionResult> EditGame(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            ViewData["Classification_Id"] = new SelectList(_context.Classification, "Id", "Description", game.Classification_Id);
            ViewData["Genre_Id"] = new SelectList(_context.Genre, "Id", "Description", game.Genre_Id);
            ViewData["Genre2_Id"] = new SelectList(_context.Genre, "Id", "Description", game.Genre2_Id);

            return View(game);
        }

        // POST: Games/EditGame/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGame(
   int id,
   [Bind("Id,Title,Producer,price,Url,Classification_Id,Genre_Id,Genre2_Id")] Game game,
   IFormFile mainImageFile,
   IFormFile bannerImageFile,
   List<IFormFile> additionalImageFiles)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Recupera o jogo original do banco de dados
                    var existingGame = await _context.Game.FindAsync(id);
                    if (existingGame == null)
                    {
                        return NotFound();
                    }

                    // Atualiza os campos editáveis
                    existingGame.Title = game.Title;
                    existingGame.Producer = game.Producer;
                    existingGame.price = game.price;
                    existingGame.Url = game.Url;
                    existingGame.Classification_Id = game.Classification_Id;
                    existingGame.Genre_Id = game.Genre_Id;
                    existingGame.Genre2_Id = game.Genre2_Id;

                    // Define a pasta para salvar as imagens
                    var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    if (!Directory.Exists(imagesDirectory))
                    {
                        Directory.CreateDirectory(imagesDirectory);
                    }

                    // Processa a nova imagem principal, se enviada
                    if (mainImageFile != null)
                    {
                        var mainFileName = Guid.NewGuid().ToString() + Path.GetExtension(mainImageFile.FileName);
                        var mainFilePath = Path.Combine(imagesDirectory, mainFileName);
                        using (var stream = new FileStream(mainFilePath, FileMode.Create))
                        {
                            await mainImageFile.CopyToAsync(stream);
                        }
                        existingGame.ImagePath = "/images/" + mainFileName;
                    }

                    // Processa a nova imagem do banner, se enviada
                    if (bannerImageFile != null)
                    {
                        var bannerFileName = Guid.NewGuid().ToString() + Path.GetExtension(bannerImageFile.FileName);
                        var bannerFilePath = Path.Combine(imagesDirectory, bannerFileName);
                        using (var stream = new FileStream(bannerFilePath, FileMode.Create))
                        {
                            await bannerImageFile.CopyToAsync(stream);
                        }
                        existingGame.BannerImage = "/images/" + bannerFileName;
                    }

                    // Processa as novas imagens adicionais (até 4) se enviadas
                    if (additionalImageFiles != null && additionalImageFiles.Count > 0)
                    {
                        int index = 0;
                        foreach (var file in additionalImageFiles.Take(4))
                        {
                            var additionalFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            var additionalFilePath = Path.Combine(imagesDirectory, additionalFileName);
                            using (var stream = new FileStream(additionalFilePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                            var relativePath = "/images/" + additionalFileName;
                            if (index == 0)
                                existingGame.AdditionalImage1 = relativePath;
                            else if (index == 1)
                                existingGame.AdditionalImage2 = relativePath;
                            else if (index == 2)
                                existingGame.AdditionalImage3 = relativePath;
                            else if (index == 3)
                                existingGame.AdditionalImage4 = relativePath;
                            index++;
                        }
                    }

                    _context.Update(existingGame);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(GameUser));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Recarrega os dropdowns em caso de erro de validação
            ViewData["Classification_Id"] = new SelectList(_context.Classification, "Id", "Description", game.Classification_Id);
            ViewData["Genre_Id"] = new SelectList(_context.Genre, "Id", "Description", game.Genre_Id);
            ViewData["Genre2_Id"] = new SelectList(_context.Genre, "Id", "Description", game.Genre2_Id);
            return View(game);
        }




        // GET: Games/Delete/5
        public async Task<IActionResult> DeleteGame(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Classification)
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("DeleteGame")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedGame(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game != null)
            {
                _context.Game.Remove(game);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GameUser));
        }



        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }

    }
}
