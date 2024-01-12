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

        public async Task Adicionar(Agendamento entity)
        {
            await _agendamentoRepository.Adicionar(entity);
        }

        public async Task Atualizar(Agendamento entity)
        {
            await _agendamentoRepository.Atualizar(entity);
        }

        public async Task<Agendamento> ObterPorId(long id)
        {
            return await _agendamentoRepository.ObterPorId(id);
        }

        public async Task<List<Agendamento>> ObterTodos()
        {
            return await _agendamentoRepository.ObterTodos();
        }

        public async Task Remover(long id)
        {
            await _agendamentoRepository.Remover(id);
        }

        public void InserirFilaAgendamento(Agendamento agendamento)
        {
            _agendamentoRepository.InserirFilaAgendamento(agendamento);
        }

        public async Task CancelarAgendamento(long id)
        {
            await _agendamentoRepository.CancelarAgendamento(id);
        }
    }
}
