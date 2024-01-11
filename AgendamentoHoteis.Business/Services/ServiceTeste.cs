using AgendamentoHoteis.Business.Interfaces;
using AgendamentoHoteis.Business.Models;
using System.Collections.Generic;

namespace AgendamentoHoteis.Business.Services
{
    public class ServiceTeste : ITesteService
    {
        private readonly IRepositorioTeste _testeRepository;


        public ServiceTeste(IRepositorioTeste testeRepository)
        {
            _testeRepository = testeRepository;
        }

        public async Task<List<Teste>> BuscarTodos()
        {
            return await _testeRepository.BuscarTodos();
        }
    }
}
