using Application;
using Infra.DataBase;
using Infra.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnection"),
            b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        services.AddRepositories();
        services.AddApplication();

        return services;
    }
}
