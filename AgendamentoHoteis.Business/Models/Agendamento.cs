using System.Text.Json.Serialization;


namespace AgendamentoHoteis.Business.Models
{
    public class Agendamento : Entity
    {
        public DateTime DataAgendamento { get; set; }
        public long IdUsuario { get; set; }
        [JsonIgnore]
        public bool Cancelado { get; set;}
    }
}
