﻿using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.web.Controllers
{
    [Route(ConstantesController.ROTA_GENERO)]
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
        [HttpPost(ConstantesController.ADICIONAR)]
        public IActionResult Adicionar([FromBody] Genero genero)
        {
            if (genero == null) { return BadRequest(); }
            _generoServico.Cadastrar(genero);
            genero.Id = _generoServico.ObterTodos().Last().Id;
            return Created($"genero/{genero.Id}", genero);
        }
        [HttpGet(ConstantesController.ID)]
        public IActionResult ObterPorId(int id)
        {
            var genero = _generoServico.ObterPorId(id);
            if (genero == null) { return NotFound(); }
            return Ok(genero);
        }
        [HttpPut(ConstantesController.ATUALIZAR)]
        public IActionResult Atualizar([FromBody] Genero genero)
        {
            if (genero == null) { return BadRequest(); }
            _generoServico.Atualizar(genero);
            genero = _generoServico.ObterTodos().Last();
            return Created($"genero/{genero.Id}", genero);
        }
        [HttpDelete(ConstantesController.DELETAR)]
        public IActionResult Deletar([FromQuery]int id)
        {
            if (id == 0) { return BadRequest(); }
            _animeGeneroServico.DeletarPorAnime(id);
            _generoServico.Deletar(id);
            return Ok();
        }
    }
}
