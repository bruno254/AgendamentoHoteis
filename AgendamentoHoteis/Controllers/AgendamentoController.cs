using AgendamentoHoteis.Business.Dto;
using AgendamentoHoteis.Business.Interfaces;
using AgendamentoHoteis.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

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
        public async Task Agendar([FromBody] AgendamentoDTO value)
        {
            Agendamento obj = new Agendamento();
            obj.DataAgendamento = value.DataAgendamento;
            obj.NroQuarto = value.NroQuarto;
            obj.IdUsuario = value.IdUsuario;

            await _agendamentoService.InserirFilaAgendamento(obj);
        }

        [Route("ConsultarAgendamentosPorUsuario")]
        [HttpGet]
        public async Task<List<Agendamento>> ConsultarAgendamentos([FromQuery] BuscaPorUsuarioDto dto)
        {
            return await _agendamentoService.BuscaPorUsuario(dto.IdUsuario);
        }

        [HttpPut("{id}")]
        public async Task CancelarAgendamento(long id)
        {
            await _agendamentoService.CancelarAgendamento(id);
        }

    }
}
