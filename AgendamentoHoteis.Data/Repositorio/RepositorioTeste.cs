using AgendamentoHoteis.Business.Interfaces;
using AgendamentoHoteis.Business.Models;
using AgendamentoHoteis.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoHoteis.Data.Repositorio
{
    public class RepositorioTeste : RepositorioBase<Teste>, IRepositorioTeste
    {
        public RepositorioTeste(AppDbContext context) : base(context) { 
        }

        public async Task<List<Teste>> BuscarTodos()
        {
            var lista = new List<Teste>();

            lista = await Db.Teste.ToListAsync();

            return lista;
        }

        public async Task<Teste> BuscarPorId(long id)
        {
            var obj = new Teste();

            obj = await Db.Teste.Where(x => x.Id == id).FirstOrDefaultAsync();

            return obj;
        }


    }
}
