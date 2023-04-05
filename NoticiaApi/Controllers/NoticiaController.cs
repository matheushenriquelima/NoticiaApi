using Microsoft.AspNetCore.Mvc;
using NoticiaApi.Model;

namespace NoticiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiaController : ControllerBase
    {
        private static List<Noticia> noticias = new List<Noticia>()
        {
            new Noticia("Roubo na augusta", "Jose", "Roubo aconteceu na augusta"),
            new Noticia("Assassinato", "Jose", "Assasinato aconteceu na 13 de maio")
        };

        private readonly ILogger<NoticiaController> _logger;

        public NoticiaController(ILogger<NoticiaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Consultando todas as noticias");
            return Ok(noticias);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Noticia noticia)
        {
            _logger.LogInformation("Criando nova noticia");
            noticias.Add(noticia);
            return Created("/noticia", noticia);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            _logger.LogInformation("buscando noticia por id");
            if (id == null) return NotFound();

            var noticia = noticias.Where(noticia => noticia.Id.ToString().Equals(id)).FirstOrDefault();
            return Ok(noticia);
        }


        [HttpPut("{id}")]
        public IActionResult Edit(string id, [FromBody] Noticia noticia)
        {
            _logger.LogInformation("atualizando noticia por id");
            var editUser = GetNoticia(id);
            if (editUser == null) return NoContent();

            editUser.Titulo = noticia.Titulo;
            editUser.Autor = noticia.Autor;
            editUser.Conteudo = noticia.Conteudo;

            return Ok(editUser);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _logger.LogInformation("deletando noticia por id");
            if (id == null) return NotFound();
            Noticia? noticia = GetNoticia(id);

            if (noticia == null) return NotFound();

            noticias.Remove(noticia);

            return Ok("noticia removida com sucesso!");
        }

        private Noticia? GetNoticia(string id)
        {
            return noticias.Where(noticia => noticia.Id.ToString().Equals(id)).FirstOrDefault();
        }
    }
}