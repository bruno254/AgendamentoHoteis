using AgendamentoHoteis.Business.Models;

namespace AgendamentoHoteis.Business.Interfaces
{
    public interface IAgendamentoService
    {
        Task InserirFilaAgendamento(Agendamento agendamento);
        Task CancelarAgendamento(long id);
        Task<List<Agendamento>> BuscaPorUsuario(long idUsuario);
    }
}
