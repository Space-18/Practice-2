using Biblioteca.Application;
using Biblioteca.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Configuration
{
    public static class ConfigurationServicesRegistration
    {
        public static IServiceCollection AddConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddPersistenceService(configuration);
            services.AddApplicationServices();

            return services;
        }
    }
}
