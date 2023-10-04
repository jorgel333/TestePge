using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infra.DataBase.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.DataBase;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProcessoJudicialRepository, ProcessoJudicialRepository>();
        services.AddScoped<IDocumentoRepository, DocumentoRepository>();
        services.AddScoped<IAdvogadoRepository, AdvogadoRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IUnityOfWork, UnityOfWork>();

        return services;
    }
}
