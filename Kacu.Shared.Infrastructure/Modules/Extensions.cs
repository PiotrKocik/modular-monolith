using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kacu.Shared.Abstraction.Events;
using Kacu.Shared.Abstraction.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Kacu.Shared.Infrastructure.Modules
{
    public static class Extensions
    {
        internal static IServiceCollection AddModuleRequests(this IServiceCollection services,
            IList<Assembly> assemblies)
        {
            services.AddModuleRegistry(assemblies);
            services.AddSingleton<IModuleClient, ModuleClient>();
            services.AddSingleton<IModuleSerializer, ModuleSerializer>();
            return services;
        }

        private static void AddModuleRegistry(this IServiceCollection services, IList<Assembly> assemblies)
        {
            var registry = new ModuleRegistry();
            var types = assemblies.SelectMany(x => x.GetTypes()).ToArray();

            var eventTypes = types
                .Where(t => t.IsClass && typeof(IEvent).IsAssignableFrom(t))
                .ToArray();

            services.AddSingleton<IModuleRegistry>(sp =>
            {
                var eventDispatcher = sp.GetService<IEventDispatcher>();
                var eventDispatcherType = eventDispatcher.GetType();

                foreach (var eventType in eventTypes)
                {
                    registry.AddRegistry(eventType, @event =>
                        (Task)eventDispatcherType.GetMethod(nameof(eventDispatcher.PublishAsync))
                            ?.MakeGenericMethod(eventType)
                            .Invoke(eventDispatcher, new[] { @event }));
                }

                return registry;
            });
        }
    }
}
