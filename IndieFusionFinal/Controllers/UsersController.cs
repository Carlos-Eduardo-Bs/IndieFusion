using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndieFusionFinal.Models;
using IndieFusionFinal.Data;


namespace Indie.Controllers
{
    public class UsersController : Controller
    {
        private readonly IndieFusionFinalContext _context;

        public UsersController(IndieFusionFinalContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index(string nomeUser)
        {

            var query = _context.User.Include(u => u.UserType).AsQueryable();

            if (!string.IsNullOrEmpty(nomeUser))
            {
                query = query.Where(u => u.Name.Contains(nomeUser));
            }

            var users = await query.ToListAsync();

            ViewData["NomeUser"] = nomeUser;

            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["UserTp"] = new SelectList(_context.UserType, "Id", "Description");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,NickName,Email,Password,BirthDate,UserTp,Games")] User user, IFormFile imageFile)
        {
            ModelState.Remove("Games");
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário não autenticado.");
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string relativePath = null;

                    if (imageFile != null && imageFile.Length > 0)
                    {
                        // Diretório do Web
                        var webImagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                        if (!Directory.Exists(webImagesDirectory))
                            Directory.CreateDirectory(webImagesDirectory);

                        // Diretório da API
                        var apiImagesDirectory = @"C:\Users\carlos.ebserra\source\repos\Projeto Final\Projeto Final\IndieFusionAPI\wwwroot\images";
                        if (!Directory.Exists(apiImagesDirectory))
                            Directory.CreateDirectory(apiImagesDirectory);

                        // Gerar um nome único para a imagem
                        var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                        var filePathWeb = Path.Combine(webImagesDirectory, uniqueFileName);
                        var filePathAPI = Path.Combine(apiImagesDirectory, uniqueFileName);

                        // Salvar a imagem no Web
                        using (var stream = new FileStream(filePathWeb, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(stream);
                        }

                        // Copiar para a pasta da API
                        System.IO.File.Copy(filePathWeb, filePathAPI, true);

                        // Definir o caminho relativo para o banco
                        relativePath = "/images/" + uniqueFileName;
                        user.ImagePath = relativePath;
                    }

                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao criar usuário: {ex.Message}");
                }
            }

            ViewData["UserTp"] = new SelectList(_context.UserType, "Id", "Description", user.UserTp);
            return View(user);
        }


        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["UserTp"] = new SelectList(_context.UserType, "Id", "Description", user.UserTp);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NickName,Email,Password,BirthDate,UserTp,ImagePath")] User user, IFormFile? imageFile)
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

                    // Diretório do Web
                    var webImagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    if (!Directory.Exists(webImagesDirectory))
                        Directory.CreateDirectory(webImagesDirectory);

                    // Diretório da API
                    var apiImagesDirectory = @"C:\Users\carlos.ebserra\source\repos\Projeto Final\Projeto Final\IndieFusionAPI\wwwroot\images";
                    if (!Directory.Exists(apiImagesDirectory))
                        Directory.CreateDirectory(apiImagesDirectory);

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePathWeb = Path.Combine(webImagesDirectory, uniqueFileName);
                    var filePathAPI = Path.Combine(apiImagesDirectory, uniqueFileName);

                    // Salvar a imagem no Web
                    using (var stream = new FileStream(filePathWeb, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Copiar para a pasta da API
                    System.IO.File.Copy(filePathWeb, filePathAPI, true);

                    // Definir o caminho relativo para o banco
                    existingUser.ImagePath = "/images/" + uniqueFileName;
                }

                _context.Entry(existingUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar: {ex.Message}");
                return View(user);
            }
        }


        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        // GET: Users


    }
}
