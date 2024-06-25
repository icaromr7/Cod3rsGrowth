using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Cod3rsGrowth.web.Controllers
{
    [Route("api/anime")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private AnimeServico _animeServico;
        private FiltroAnime _filtro = null;

        public AnimeController(AnimeServico animeServico)
        {
            _animeServico = animeServico;
            _filtro = new FiltroAnime();
        }
        [HttpGet("obter_animes")]
        public IActionResult Get([FromBody] FiltroAnime filtro)
        {
            if (filtro == null) { return BadRequest(); }
            var animes = _animeServico.ObterTodos(filtro);
            return Ok(animes);
        }
        [HttpPost("cadastrar_anime")]
        public IActionResult AdicionarAnime([FromBody] Anime anime)
        {
            if (anime == null) { return BadRequest(); }
            _animeServico.Cadastrar(anime);
            anime.Id = _animeServico.ObterTodos(null).Last().Id;
            return Created($"anime/{anime.Id}", anime);
        }

        [HttpGet("{idanime}")]
        public IActionResult ObterPorId([FromBody] int id)
        {
            if (id == 0) { return BadRequest(); }
            var anime = _animeServico.ObterPorId(id);
            return Ok(anime);
        }
        [HttpPost("Atualizar")]
        public IActionResult AtualizarAnime([FromBody]Anime anime)
        {
            if (anime == null) { return BadRequest(); }
            _animeServico.Atualizar(anime);
            anime= _animeServico.ObterTodos(null).Last();
            return Created($"anime/{anime.Id}", anime);
        }
    }

}