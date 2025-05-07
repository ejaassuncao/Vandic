using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vandic.CrossCutting.Meditor.Interfaces;

namespace Vandic.CrossCutting.Meditor.Configurations
{
    public static class InjectCommandDispatcher
    {
        public static IServiceCollection AddDispatcher(this IServiceCollection services, Action<CommandDispatcherConfiguration> configuration)
        {
            CommandDispatcherConfiguration mediatRServiceConfiguration = new CommandDispatcherConfiguration();
            configuration(mediatRServiceConfiguration);

            return services.AddDispatcher(mediatRServiceConfiguration);
        }

        public static IServiceCollection AddDispatcher(this IServiceCollection services, CommandDispatcherConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (!configuration.AssembliesToRegister.Any())
                throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for handlers.");

            var assemblies = configuration.AssembliesToRegister.Distinct().ToArray();

            RegisterHandlers(services, assemblies, typeof(IRequestHandler<,>));
            RegisterHandlers(services, assemblies, typeof(INotificationHandler<>));

            // Registra o dispatcher principal
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();

            return services;
        }

        private static void RegisterHandlers(IServiceCollection services, Assembly[] assemblies, Type handlerInterfaceType)
        {
            foreach (var assembly in assemblies)
            {
                var handlerTypes = assembly.GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract)
                    .SelectMany(t => t.GetInterfaces()
                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType)
                        .Select(i => new { Interface = i, Implementation = t }))
                    .Distinct(); // evita duplicações

                foreach (var handler in handlerTypes)
                {
                    services.AddTransient(handler.Interface, handler.Implementation);
                }
            }
        }
    }
}
