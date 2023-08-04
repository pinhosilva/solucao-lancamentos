using Infra.Dapper.Extensions;
using Infra.EF.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Extensions;

namespace CrossCutting.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddServices()
                .AddFinders()
                .AddSqlDbContext(configuration);

            return services;
        }
    }
}