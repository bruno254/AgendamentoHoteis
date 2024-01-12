using AgendamentoHoteis.Business.Models;

namespace AgendamentoHoteis.Business.Interfaces
{
    public interface IAgendamentoRepositorio : IRepositorioBase<Agendamento>
    {
        void InserirFilaAgendamento(Agendamento agendamento);
        Task CancelarAgendamento(long id);
        void InseriAgendamentos();
    }
}
