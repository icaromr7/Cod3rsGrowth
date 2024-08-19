using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Cod3rsGrowth.web.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.web.Controllers
{
    [Route("api/anime")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private AnimeServico _animeServico;
        private AnimeGeneroServico _animeGeneroServico;
        const int POSICAO_INICIAL_NA_LISTA = 0;

        public AnimeController(AnimeServico animeServico, AnimeGeneroServico animeGeneroServico)
        {
            _animeServico = animeServico;
            _animeGeneroServico = animeGeneroServico;
        }
        [HttpGet()]
        public IActionResult Get([FromQuery] FiltroAnime filtro)
        {
            var animes = _animeServico.ObterTodos(filtro);
            return Ok(animes);
        }
        [HttpPost("adicionar")]
        public IActionResult Adicionar([FromBody] Anime anime)
        {
            int idAnime = _animeServico.Cadastrar(anime);
            anime.Id = idAnime;
            foreach (int id in anime.IdGeneros)
            {
                var animeGenero = new AnimeGenero()
                {
                    IdAnime = idAnime,
                    IdGenero = id
                };
                _animeGeneroServico.Cadastrar(animeGenero);
            }
            return Created($"anime/{anime.Id}", anime);
        }
        
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var anime = _animeServico.ObterPorId(id);
            var animeGeneros = _animeGeneroServico.ObterTodos(id);
            anime.IdGeneros = new List<int>();
            foreach (var item in animeGeneros)
            {
                anime.IdGeneros.Add(item.IdGenero);
            }
            if (anime == null) { return BadRequest(); }
            return Ok(anime);
        }
        [HttpPut ("atualizar")]
        public IActionResult Atualizar([FromBody]Anime anime)
        {
            _animeServico.Atualizar(anime);
            var animeGeneros = _animeGeneroServico.ObterTodos(anime.Id);
            var generosAntigos = new List<int>();
            foreach (var item in animeGeneros)
            {
                generosAntigos.Add(item.IdGenero);
            }
            MetodosAuxiliares.ExcluirRelacaoAnimeGenero(anime, generosAntigos, _animeGeneroServico);
            MetodosAuxiliares.AdicionarRelacaoAnimeGenero(anime, generosAntigos, _animeGeneroServico);
            return Ok();
        }
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar([FromRoute]int id)
        {          
            _animeGeneroServico.DeletarPorAnime(id);
            _animeServico.Deletar(id);
            return Ok();          
        }
        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            var status = _animeServico.getDescricaoEnum();
            return Ok(status);
        }
        
    }

}