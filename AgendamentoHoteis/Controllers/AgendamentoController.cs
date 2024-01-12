using AgendamentoHoteis.Business.Interfaces;
using AgendamentoHoteis.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoHoteis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;

        public AgendamentoController(IAgendamentoService AgendamentoService) : base()
        {
            _agendamentoService = AgendamentoService;
        }

        // GET: api/<AgendamentoController>
        [HttpGet]
        public async Task<List<Agendamento>> Index()
        {
            return await _agendamentoService.ObterTodos();
        }

        // GET api/<AgendamentoController>/5
        [HttpGet("{id}")]
        public async Task<Agendamento> Get(int id)
        {
            return await _agendamentoService.ObterPorId(id);
        }

        // POST api/<AgendamentoController>
        [HttpPost]
        public async Task Post([FromBody] Agendamento value)
        {
            await _agendamentoService.Adicionar(value);
        }

        // PUT api/<AgendamentoController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Agendamento value)
        {
            await _agendamentoService.Atualizar(value);
        }
    }
}
