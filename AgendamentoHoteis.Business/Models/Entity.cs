using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AgendamentoHoteis.Business.Models
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}
