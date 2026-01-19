using ArcadeService.DL.Interfaces;
using ArcadeService.DL.Repositories;
using ArcadeService.Models.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace ArcadeService.DL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(
            this IServiceCollection services,
            IConfiguration configs)
        {
            BsonSerializer.RegisterSerializer(
                new GuidSerializer(GuidRepresentation.Standard));

            services
                .AddConfigurations(configs)
                .AddSingleton<IArcadeMachineRepository, ArcadeMachineLocalRepository>()
                .AddSingleton<ICustomerRepository, CustomerLocalRepository>();

            return services;
        }

        private static IServiceCollection AddConfigurations(
            this IServiceCollection services,
            IConfiguration configs)
        {
            services.Configure<MongoDbConfiguration>(
                configs.GetSection(nameof(MongoDbConfiguration)));

            return services;
        }
    }
}
