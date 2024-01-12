using AgendamentoHoteis.Business.Interfaces;
using AgendamentoHoteis.Business.Models;
using AgendamentoHoteis.Data.Context;

namespace AgendamentoHoteis.Data.Repositorio
{
    public class AgendamentoRepositorio : RepositorioBase<Agendamento>, IAgendamentoRepositorio
    {
        public AgendamentoRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}
