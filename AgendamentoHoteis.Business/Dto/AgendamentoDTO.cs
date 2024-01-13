using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamentoHoteis.Business.Dto
{
    public class AgendamentoDTO
    {
        public DateTime DataAgendamento { get; set; }
        public long IdUsuario { get; set; }
        public long NroQuarto { get; set; }
    }
}
