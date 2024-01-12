using System.ComponentModel.DataAnnotations;

namespace AgendamentoHoteis.Business.Models
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}
