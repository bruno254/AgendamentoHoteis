using AgendamentoHoteis.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoHoteis.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Teste> Teste { get; set; }
    }
}
