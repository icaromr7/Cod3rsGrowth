using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.web.Controllers
{
    [Route("api/Genero")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private GeneroServico _generoServico;
        public GeneroController(GeneroServico generoServico) { 
            _generoServico = generoServico;
        }
        [HttpGet("obter_generos")]
        public IActionResult Get()
        {
            var generos = _generoServico.ObterTodos();
            return Ok(generos);
        }
        [HttpPost("cadastrar_genero")]
        public IActionResult AdicionarAnime([FromBody] Genero genero)
        {
            if (genero == null) { return BadRequest(); }
            _generoServico.Cadastrar(genero);
            genero.Id = _generoServico.ObterTodos().Last().Id;
            return Created($"anime/{genero.Id}", genero);
        }
        [HttpGet("{idgenero}")]
        public IActionResult ObterPorId([FromBody] int id)
        {
            if (id == 0) { return BadRequest(); }
            var genero = _generoServico.ObterPorId(id);
            return Ok(genero);
        }
        [HttpPost("Atualizar")]
        public IActionResult AtualizarAnime([FromBody] Genero genero)
        {
            if (genero == null) { return BadRequest(); }
            _generoServico.Atualizar(genero);
            genero = _generoServico.ObterTodos().Last();
            return Created($"anime/{genero.Id}", genero);
        }
    }
}
