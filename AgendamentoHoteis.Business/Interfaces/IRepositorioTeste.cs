using AgendamentoHoteis.Business.Models;

namespace AgendamentoHoteis.Business.Interfaces
{
    public interface IRepositorioTeste : IRepositorioBase<Teste>
    {
        Task<List<Teste>> BuscarTodos();
        Task<Teste> BuscarPorId(long id);
    }
}
