using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndieFusionFinal.Models;
using System.IO;
using IndieFusionFinal.Data;

namespace Indie.Controllers
{
    public class GamesController : Controller
    {
        private readonly IndieFusionFinalContext _context;

        public GamesController(IndieFusionFinalContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index(string NomeJogo, int? Classification_Id, int? Genre_Id, int? Genre2_Id)
        {
            var games = _context.Game
                                .Include(g => g.Classification)
                                .Include(g => g.Genre)
                                .Include(g => g.Genre2)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(NomeJogo))
            {
                games = games.Where(g => g.Title.Contains(NomeJogo));
            }

            if (Classification_Id.HasValue)
            {
                games = games.Where(g => g.Classification_Id == Classification_Id.Value);
            }

            if (Genre_Id.HasValue)
            {
                games = games.Where(g => g.Genre_Id == Genre_Id.Value);
            }

            if (Genre2_Id.HasValue)
            {
                games = games.Where(g => g.Genre2_Id == Genre2_Id.Value);
            }

            ViewBag.Classification_Id = new SelectList(await _context.Classification.ToListAsync(), "Id", "Description", Classification_Id);
            ViewBag.Genre_Id = new SelectList(await _context.Genre.ToListAsync(), "Id", "Description", Genre_Id);
            ViewBag.Genre2_Id = new SelectList(await _context.Genre.ToListAsync(), "Id", "Description", Genre2_Id);
            ViewData["NomeJogo"] = NomeJogo;

            return View(await games.ToListAsync());
        }

        public IActionResult Filtro(string nomeJogo, int? Classification_Id, int? Genre_Id, int? Genre2_Id)
        {

            // Consulta para todos os jogos (sem restrição por usuário)
            var jogos = _context.Game
                                .Include(g => g.Classification)
                                .Include(g => g.Genre)
                                .Include(g => g.Genre2)
                                .AsQueryable();

            // Filtro por nome do jogo
            if (!string.IsNullOrEmpty(nomeJogo))
            {
                jogos = jogos.Where(g => g.Title.Contains(nomeJogo));
            }

            // Filtro por classificação
            if (Classification_Id.HasValue)
            {
                jogos = jogos.Where(g => g.Classification_Id == Classification_Id.Value);
            }

            // Filtro por gênero primário
            if (Genre_Id.HasValue)
            {
                jogos = jogos.Where(g => g.Genre_Id == Genre_Id.Value);
            }

            // Filtro por gênero secundário
            if (Genre2_Id.HasValue)
            {
                jogos = jogos.Where(g => g.Genre2_Id == Genre2_Id.Value);
            }

            // Preenche os ViewBag com as classificações e gêneros para o dropdown
            ViewBag.Classification_Id = new SelectList(_context.Classification, "Id", "Description", Classification_Id);
            ViewBag.Genre_Id = new SelectList(_context.Genre, "Id", "Description", Genre_Id);
            ViewBag.Genre2_Id = new SelectList(_context.Genre, "Id", "Description", Genre2_Id);

            // Passa os filtros para a ViewData para manter os valores no filtro
            ViewData["NomeJogo"] = nomeJogo;

            // Retorna a lista de jogos filtrados
            return View(jogos.ToList());
        }


        public async Task<IActionResult> Details(int? id)
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
        public IActionResult Create()
        {
            ViewData["Classification_Id"] = new SelectList(_context.Classification, "Id", "Description");
            ViewData["Genre_Id"] = new SelectList(_context.Genre, "Id", "Description");
            ViewData["Genre2_Id"] = new SelectList(_context.Genre, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
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
                    return RedirectToAction(nameof(Index));
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











        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

            // Popula os dropdowns de Classificação e Gênero, incluindo o segundo gênero
            ViewData["Classification_Id"] = new SelectList(_context.Classification, "Id", "Description", game.Classification_Id);
            ViewData["Genre_Id"] = new SelectList(_context.Genre, "Id", "Description", game.Genre_Id);
            ViewData["Genre2_Id"] = new SelectList(_context.Genre, "Id", "Description", game.Genre2_Id);

            return View(game);
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
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

                    return RedirectToAction(nameof(Index));
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




        // Método auxiliar para remover arquivos
        private void DeleteFile(string imagePath)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagePath.TrimStart('/'));
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }


        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game != null)
            {
                // Remove o jogo do banco de dados
                _context.Game.Remove(game);

                // Exclui a imagem associada, se existir
                if (!string.IsNullOrEmpty(game.ImagePath))
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", game.ImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método auxiliar para verificar se o jogo existe
        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}