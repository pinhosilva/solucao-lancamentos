using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Web.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection SwaggerConfigure(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Solução de lançamentos",
                    Version = "1.0",
                    Description = "Avaliação para uma solução de lançamentos",
                    Contact = new OpenApiContact
                    {
                        Name = "Serviços para solução de lançamentos"
                    }
                });
            });

            return services;
        }
    }
}
