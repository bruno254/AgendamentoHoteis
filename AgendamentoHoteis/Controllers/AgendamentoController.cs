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

        [Route("Agendar")]
        [HttpPost]
        public void Agendar([FromBody] Agendamento value)
        {
            _agendamentoService.InserirFilaAgendamento(value);
        }

        [Route("ConsultarAgendamentos")]
        [HttpGet]
        public async Task<List<Agendamento>> ConsultarAgendamentos()
        {
            return await _agendamentoService.ObterTodos();
        }

        [HttpPut("{id}")]
        public async Task CancelarAgendamento(long id)
        {
            await _agendamentoService.CancelarAgendamento(id);
        }

        [Route("InserirAgendamentos")]
        [HttpPost]
        public void InserirAgendamentos()
        {
            _agendamentoService.InserirAgendamentos();
        }

    }
}
