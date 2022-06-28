using eCommenceAPI.Application.Abstractions.Storage;
using eCommenceAPI.Infrastructure.Enums;
using eCommenceAPI.Infrastructure.Services.Storage;
using eCommenceAPI.Infrastructure.Services.Storage.Azure;
using eCommenceAPI.Infrastructure.Services.Storage.Local;
using Microsoft.Extensions.DependencyInjection;

namespace eCommenceAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
        {
            services.AddScoped<IStorage, T>();
        }

        public static void AddStorage(this IServiceCollection services, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    services.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:
                    break;
                default:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
