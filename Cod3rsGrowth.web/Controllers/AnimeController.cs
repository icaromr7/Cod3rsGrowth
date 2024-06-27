using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.web.Controllers
{
    [Route(ConstantesController.ROTA_ANIME)]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private AnimeServico _animeServico;
        private AnimeGeneroServico _animeGeneroServico;
        private FiltroAnime _filtro = null;

        public AnimeController(AnimeServico animeServico, AnimeGeneroServico animeGeneroServico)
        {
            _animeServico = animeServico;
            _filtro = new FiltroAnime();
            _animeGeneroServico = animeGeneroServico;
        }
        [HttpGet()]
        public IActionResult Get([FromQuery] FiltroAnime filtro)
        {
            var animes = _animeServico.ObterTodos(filtro);
            return Ok(animes);
        }
        [HttpPost(ConstantesController.ADICIONAR)]
        public IActionResult Adicionar([FromBody] Anime anime)
        {
            if (anime == null) { return BadRequest(); }
            _animeServico.Cadastrar(anime);
            anime.Id = _animeServico.ObterTodos(null).Last().Id;
            return Created($"anime/{anime.Id}", anime);
        }

        [HttpGet(ConstantesController.ID)]
        public IActionResult ObterPorId(int id)
        {
            var anime = _animeServico.ObterPorId(id);
            if (anime == null) { return BadRequest(); }
            return Ok(anime);
        }
        [HttpPut (ConstantesController.ATUALIZAR)]
        public IActionResult Atualizar([FromBody]Anime anime)
        {
            if (anime == null) { return BadRequest(); }
            _animeServico.Atualizar(anime);
            anime = _animeServico.ObterPorId(anime.Id);
            return Created($"anime/{anime.Id}", anime);
        }
        [HttpDelete(ConstantesController.DELETAR)]
        public IActionResult Deletar([FromQuery] int id)
        {
            if ( id ==0) { return BadRequest(); }
            _animeGeneroServico.DeletarPorAnime(id);
            _animeServico.Deletar(id);
            return Ok();
        }
    }

}