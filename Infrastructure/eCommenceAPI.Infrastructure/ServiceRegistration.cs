using eCommenceAPI.Application.Services;
using eCommenceAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommenceAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
        }
    }
}
