using AgendamentoHoteis.Business.Dto;
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

        [HttpPost("Agendar")]
        public async Task Agendar([FromBody] AgendamentoDTO value)
        {
            Agendamento obj = new Agendamento();
            obj.DataAgendamento = value.DataAgendamento;
            obj.NroQuarto = value.NroQuarto;
            obj.IdUsuario = value.IdUsuario;

            await _agendamentoService.InserirFilaAgendamento(obj);
        }

        [HttpGet("ConsultarAgendamentosPorUsuario")]
        public async Task<List<Agendamento>> ConsultarAgendamentosPorUsuario([FromQuery] BuscaPorUsuarioDto dto)
        {
            return await _agendamentoService.BuscaPorUsuario(dto.IdUsuario);
        }

        [HttpGet("ConsultarAgendamentos")]
        public async Task<List<Agendamento>> ConsultarAgendamentos()
        {
            return await _agendamentoService.BuscarTodosAgendamentos();
        }

        [HttpPut("CancelarAgendamento/{id}")]
        public async Task CancelarAgendamento([FromRoute] long id)
        {
            await _agendamentoService.CancelarAgendamento(id);
        }

    }
}
