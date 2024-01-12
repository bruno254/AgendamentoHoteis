﻿using AgendamentoHoteis.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamentoHoteis.Business.Interfaces
{
    public interface IAgendamentoService
    {
        Task<List<Agendamento>> ObterTodos();
        Task<Agendamento> ObterPorId(long id);
        Task Adicionar(Agendamento entity);
        Task Atualizar(Agendamento entity);
    }
}
