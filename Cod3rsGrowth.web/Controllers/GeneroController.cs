using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.web.Controllers
{
    [Route("api/genero")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private GeneroServico _generoServico;
        private AnimeGeneroServico _animeGeneroServico;

        public GeneroController(GeneroServico generoServico, AnimeGeneroServico animeGeneroServico) { 
            _generoServico = generoServico;
            _animeGeneroServico = animeGeneroServico;
        }
        [HttpGet()]
        public IActionResult Get([FromQuery]string ? nome)
        {
            var generos = _generoServico.ObterTodos(nome);
            return Ok(generos);
        }
        [HttpPost("adicionar")]
        public IActionResult Adicionar([FromBody] Genero genero)
        {
            int idGenero = _generoServico.Cadastrar(genero);
            genero.Id = idGenero;
            return Created($"genero/{genero.Id}", genero);
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var genero = _generoServico.ObterPorId(id);
            if (genero == null) { return BadRequest(); }
            return Ok(genero);
        }
        [HttpGet("animeGenero/{id}")]
        public IActionResult ObterGenerosPorIdAnime(int id)
        {
            List<AnimeGenero> listAnimeGenero = _animeGeneroServico.ObterTodos(id);
            var listaGeneros = new List<Genero>();
            foreach(var item in listAnimeGenero)
            {
                var genero = _generoServico.ObterPorId(item.IdGenero);
                listaGeneros.Add(genero);
            }
            return Ok(listaGeneros);
        }
        
    [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] Genero genero)
        {
            if (genero == null) { return BadRequest(); }
            _generoServico.Atualizar(genero);
            return Ok();
        }
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar([FromRoute]int id)
        {
            _animeGeneroServico.DeletarPorGenero(id);
            _generoServico.Deletar(id);
            return Ok();
        }
    }
}
