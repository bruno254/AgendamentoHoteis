using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AgendamentoHoteis.Business.Models
{
    public class Agendamento : Entity
    {
        public DateTime DataAgendamento { get; set; }
        public long IdUsuario { get; set; }        
    }
}
