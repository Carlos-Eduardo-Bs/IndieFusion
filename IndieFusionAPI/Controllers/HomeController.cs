using Microsoft.AspNetCore.Mvc;

namespace IndieFusionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult GerarInformacao()
        {
            var result = "Sucesso porra!!";
            return Ok(result);
        }

        [HttpGet("umaNovaRotaAqui")]
        public IActionResult GetInformacao2()
        {
            var result = "Sucesso denovo !!";
            return Ok(result);
        }

        //passando um parametro pela rota
        [HttpPost("FromRoute/{parametro}")]
        public IActionResult GetInformacao3([FromRoute] string parametro)
        {
            var result = $"Mensagem com o seguinte parametro: {parametro.ToUpper()}";
            return Ok(result);
        }

        //usando post
        [HttpPost("FromQuery")]
        public IActionResult PostInformacao([FromQuery] string parametro)
        {
            var result = $"Mais uma mensagem com parametro: {parametro.ToUpper()}";
            return Ok(result);
        }

        [HttpPost("FromHeader")]
        public IActionResult PostInformacao1([FromHeader] string parametro)
        {
            var result = $"Mais uma mensagem com parametro: {parametro.ToUpper()}";
            return Ok(result);
        }

        [HttpPost("FromBody")]
        public IActionResult PostInformacao2([FromBody] Body body)
        {
            var result = $"Mais uma mensagem com parametro: {body.parametro.ToUpper()}";
            return Ok(result);
        }

        public class Body
        {
            public string parametro { get; set; }
        }
    }
}
