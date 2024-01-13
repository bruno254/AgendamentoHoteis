using AgendamentoHoteis.Business.Interfaces;
using AgendamentoHoteis.Data.Repositorio;

namespace AgendamentoHoteis.Configuration
{
    public static class AddRepositoryCollections
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IAgendamentoRepositorio, AgendamentoRepositorio>();

            return services;
        }
    }
}
