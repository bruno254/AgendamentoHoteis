using AgendamentoHoteis.Business.Models;

namespace AgendamentoHoteis.Business.Interfaces
{
    public interface IAgendamentoRepositorio : IRepositorioBase<Agendamento>
    {
        Task InserirFilaAgendamento(Agendamento agendamento);
        Task CancelarAgendamento(long id);
        Task<List<Agendamento>> BuscaPorUsuario(long idUsuario);
    }
}
