using ArcadeService.BL.Interfaces;
using ArcadeService.BL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ArcadeService.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(
            this IServiceCollection services)
        {
            services.AddSingleton<IArcadeMachineCrudService, ArcadeMachineCrudService>();
            services.AddSingleton<ISellArcadeMachine, SellArcadeMachine>();
            services.AddSingleton<ICustomerCrudService, CustomerCrudService>();

            return services;
        }
    }
}
