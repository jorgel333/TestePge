using Microsoft.OpenApi.Models;

namespace Presentation.Extensions;

public static class SwaggerExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Api de Gerenciamento de Processos Jurídicos",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Jorge Leonardo",
                    Email = "exemplodeumemailaqui@mail.com"
                }
            });

            var xmlFile = "Presentation.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}
