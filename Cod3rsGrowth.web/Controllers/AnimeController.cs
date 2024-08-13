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
        [HttpPost(ConstantesController.ADICIONAR)]
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
        
        [HttpGet(ConstantesController.ID)]
        public IActionResult ObterPorId(int id)
        {
            var anime = _animeServico.ObterPorId(id);
            var animeGeneros = _animeGeneroServico.ObterTodos(id);
            anime.IdGeneros = new List<int>();
            foreach(var item in animeGeneros)
            {
                anime.IdGeneros.Add(item.IdGenero);
            }
            return Ok(anime);
        }
        [HttpPut (ConstantesController.ATUALIZAR)]
        public IActionResult Atualizar([FromBody]Anime anime)
        {
            _animeServico.Atualizar(anime);
            return Ok();
        }
        [HttpDelete(ConstantesController.DELETAR)]
        public IActionResult Deletar(int id)
        {          
            _animeGeneroServico.DeletarPorAnime(id);
            _animeServico.Deletar(id);
            return Ok();          
        }
        [HttpGet(ConstantesController.STATUS)]
        public IActionResult GetStatus()
        {
            var status = _animeServico.getDescricaoEnum();
            return Ok(status);
        }
    }

}