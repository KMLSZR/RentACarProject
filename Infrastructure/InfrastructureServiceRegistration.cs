using Application.Services.PosService;
using Application.Services.FindeksService;
using InfraStructure.Adapters.BankServices;
using InfraStructure.Adapters.Findeks;
using Microsoft.Extensions.DependencyInjection;

namespace InfraStructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IFindeksService, FakeFindeksServiceAdapter>();
        services.AddScoped<IPosService, FakePosServiceAdapter>();
        return services;
    }
}
