using Biblioteca.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Configuration
{
    public static class ConfigurationServicesRegistration
    {
        public static IServiceCollection AddConfigurationServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddApplicationServices();

            return services;
        }
    }
}
