using AuthHub.Application;
using AuthHub.Infrastructure;

namespace AuthHub.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI();
            return services;
        }
    }
}
