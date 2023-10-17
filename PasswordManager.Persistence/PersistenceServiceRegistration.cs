using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Persistence.Context;

namespace PasswordManager.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(builder => builder.UseSqlServer(
                configuration.GetConnectionString("DefaultConnectionString"), b => b.MigrationsAssembly("PasswordManager.WebApi")));
            return services;
        }
    }
}
