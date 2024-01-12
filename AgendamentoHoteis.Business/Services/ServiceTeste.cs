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


        public async Task<Teste> BuscarPorId(long id)
        {
            return await _testeRepository.BuscarPorId(id);
        }

        public async Task Adicionar(Teste entity)
        {
            await _testeRepository.Adicionar(entity);
        }

        public async Task Atualizar(Teste entity)
        {
            await _testeRepository.Atualizar(entity);
        }

        public async Task Remover(long id)
        {
            await _testeRepository.Remover(id);
        }
    }
}
