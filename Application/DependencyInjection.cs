using Application.Behaviours;
using Application.Features.AdvogadoFeatures.Cadastrar;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(CadastrarAdvogadoCommandValidator));
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationHandlingBehaviour<,>));


        return services;
    }
}
