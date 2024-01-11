using AgendamentoHoteis.Business.Interfaces;
using AgendamentoHoteis.Business.Services;

namespace AgendamentoHoteis.Configuration
{
    public static class AddServicesCollections
    {
        public static IServiceCollection AddServiceAplication(this IServiceCollection services)
        {
            services.AddTransient<ITesteService, ServiceTeste>();

            return services;
        }
    }
}
