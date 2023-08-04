using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Name.EndsWith("Service"))
                .ToDictionary(i => i.GetInterfaces().First(), t => t);

            foreach (var (service, implementation) in types)
            {
                services.AddTransient(service, implementation);
            }

            return services;
        }
    }
}