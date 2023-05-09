using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace METROAssignment.Application
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR((configuration) => {
                configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            return services;
        }

    }
}
