using AgendamentoHoteis.Business.Interfaces;
using AgendamentoHoteis.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgendamentoHoteis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly ITesteService _testeService;


        public AgendamentoController(ITesteService testeService) : base()
        {
            _testeService = testeService;
        }

        // GET: api/<AgendamentoController>
        [HttpGet]
        public async Task<List<Teste>> Index()
        {
            return await _testeService.BuscarTodos();
        }

        // GET api/<AgendamentoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AgendamentoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AgendamentoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AgendamentoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
