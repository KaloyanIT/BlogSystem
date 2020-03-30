using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Blog.Data.Base;
using Blog.DataAccess;
using Blog.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Controllers.Helpers
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection InjectStandartServices(this IServiceCollection services)
        {
            var serviceType = typeof(IService);
            var singletonServiceType = typeof(ISingletonService);
            var scopedServiceType = typeof(IScopedService);

            var types = serviceType
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if(serviceType.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
                else if (scopedServiceType.IsAssignableFrom(type.Service))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
                else if (scopedServiceType.IsAssignableFrom(type.Service))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }

            }

            return services;
        }

        public static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            var repositoryType = typeof(ITransientRepository);

            var types = repositoryType
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Repository = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Repository != null);

            foreach(var type in types)
            {
                if(repositoryType.IsAssignableFrom(type.Repository))
                {
                    services.AddTransient(type.Repository, type.Implementation);
                }
            }

            return services;
        }
    }
}
