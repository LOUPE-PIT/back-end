using SynchronizationService.Core.API.Strategies.Provider;
using SynchronizationService.Core.API.Strategies;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SynchronizationService.DataLayer.Models.MongoDB.Interfaces;
using SynchronizationService.DataLayer.Models.MongoDB;
using SynchronizationService.Core.API.Services;
using SynchronizationService.DataLayer.Services.Interface;
using SynchronizationService.DataLayer.Services;
using SynchronizationService.API.Hubs;

namespace SynchronizationService.API.Extension_Methods
{
    public static class SynchronizationExtensions
    {
        public static void AddStrategies(this IServiceCollection services)
        {
            services.AddTransient<RotationActionStrategy>();
            services.AddTransient<TranslationActionStrategy>();
            services.AddTransient<PressActionStrategy>();

            services.AddTransient<IActionStrategy>(provider =>
                new NamedStrategyProvider("Rotate", provider.GetService<RotationActionStrategy>()!));
            services.AddTransient<IActionStrategy>(provider =>
                new NamedStrategyProvider("Translate", provider.GetService<TranslationActionStrategy>()!));
            services.AddTransient<IActionStrategy>(provider =>
                new NamedStrategyProvider("Press", provider.GetService<PressActionStrategy>()!));
        }

        public static void AddMongoDB(this IServiceCollection services, IConfigurationSection transformationDbSettings, string connectionstring)
        {
            services.Configure<TransformationsDatabaseSettings>(transformationDbSettings);
            services.AddSingleton<ITransformationsDatabaseSettings>(sp => sp.GetRequiredService<IOptions<TransformationsDatabaseSettings>>().Value);
            services.AddSingleton<IMongoClient>(s => new MongoClient(connectionstring));
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISynchronizationService, SyncService>();
            services.AddTransient<SyncLogService.SyncLogService>();
            services.AddScoped<ITransformationRepository, TransformationRepository>();
        }

        public static void AddSynchronizationHub(this IServiceCollection services)
        {
            services.AddSingleton<SynchronizationHub>();
        }
    }
}
