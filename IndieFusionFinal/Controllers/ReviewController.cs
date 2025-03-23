using IndieFusionFinal.Data;
using IndieFusionFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndieFusionFinal.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IndieFusionFinalContext _context;
        public IActionResult Index()
        {
            return View();
        }

        public ReviewController(IndieFusionFinalContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReview(int gameId, bool like, string comment)
        {
            // Verificando o usuário na sessão
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário não autenticado.");
                return RedirectToAction("Login", "Home");
            }

            var review = new Review
            {
                GameId = gameId,
                Like = like,
                Comment = comment,
                UserId = userId.Value
            };

            try
            {
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

                // Redireciona para a página TemplateJogo
                return RedirectToAction("TemplateJogo", "Templates", new { id = gameId });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }

    }
}
