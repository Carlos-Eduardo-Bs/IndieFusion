using IndieFusionFinal.Data;
using IndieFusionFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IndieFusionFinal.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly IndieFusionFinalContext _context;
        private readonly HttpClient _httpClient;
        private string API_KEY = Properties.Resources.MinhaAPI; 
       

        public NewsController(HttpClient httpClient, IndieFusionFinalContext context)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "SeuNomeDeAplicacao/1.0");
            _context = context;
        }

        // Método para buscar e salvar notícias
        [HttpGet("fetch")]
        public async Task<IActionResult> FetchNews()
        {
            string url = $"https://newsapi.org/v2/everything?q=games&language=pt&apiKey={API_KEY}";

            var response = await _httpClient.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, $"Erro ao buscar notícias: {errorContent}");
            }

            var data = JsonConvert.DeserializeObject<dynamic>(responseContent);
            List<NewsModel> newsList = new List<NewsModel>();

            foreach (var article in data.articles)
            {
                DateTime publishedAt;
                if (!DateTime.TryParse(article.publishedAt.ToString(), out publishedAt))
                {
                    publishedAt = DateTime.MinValue;
                }

                var news = new NewsModel
                {
                    Title = article.title,
                    Description = article.description,
                    UrlToImage = article.urlToImage,
                    Url = article.url,
                    SourceId = article.source.id,
                    SourceName = article.source.name,
                    PublishedAt = publishedAt
                };

                newsList.Add(news);
                _context.news.Add(news);
            }

            await _context.SaveChangesAsync();

            // Log para verificar quantas notícias foram salvas
            Console.WriteLine($"Total de notícias salvas: {newsList.Count}");

            return Ok(newsList);
        }

        // Método para exibir as notícias na view
        [HttpGet]
        public IActionResult Index()
        {
            var newsList = _context.news.ToList();
            return View(newsList);
        }
    }
}