using Infra.EF.Data;
using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using CPObjects.Infrastructure.Data;
using IUnitOfWork = Infrastructure.Core.IUnitOfWork;

namespace Infra.EF.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DataProvider>(c =>
            {
                c.SolutionDbContext = new DataProvider(configuration).SolutionDbContext;
            });

            services
                .AddDbContext<SolutionContext>(options =>
                {
                    options
                        .UseSqlServer(new DataProvider(configuration).SolutionDbContext, builder =>
                        {
                            builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                        })
                        .UseLazyLoadingProxies();
                })
                .AddScoped<SolutionContext>();

            services.AddTransient<IRepository, Repository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}