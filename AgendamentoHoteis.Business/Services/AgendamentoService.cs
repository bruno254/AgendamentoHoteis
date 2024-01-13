using AgendamentoHoteis.Business.Interfaces;
using AgendamentoHoteis.Business.Models;

namespace AgendamentoHoteis.Business.Services
{
    public class AgendamentoService : IAgendamentoService
    {

        private readonly IAgendamentoRepositorio _agendamentoRepository;

        public AgendamentoService(IAgendamentoRepositorio agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<List<Agendamento>> BuscaPorUsuario(long idUsuario)
        {
            return await _agendamentoRepository.BuscaPorUsuario(idUsuario);
        }


        public async Task InserirFilaAgendamento(Agendamento agendamento)
        {
            await _agendamentoRepository.InserirFilaAgendamento(agendamento);
        }

        public async Task CancelarAgendamento(long id)
        {
            await _agendamentoRepository.CancelarAgendamento(id);
        }
    }
}
