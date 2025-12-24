using AuthHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
namespace AuthHub.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services,IConfiguration configration)
        {

            services.AddDbContext<AppDbContext>(options=>
            options.UseSqlServer(configration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)),
              ServiceLifetime.Scoped);
            return services;
        }
    }
}
