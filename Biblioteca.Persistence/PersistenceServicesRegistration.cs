using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Contracts.Persistence.Commons;
using Biblioteca.Persistence.Repositories;
using Biblioteca.Persistence.Repositories.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("SQLConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
