using AgendamentoHoteis.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamentoHoteis.Business.Interfaces
{
    public interface ITesteService
    {
        Task<List<Teste>> BuscarTodos();
        Task<Teste> BuscarPorId(long id);
    }
}
