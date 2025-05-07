using Microsoft.Extensions.DependencyInjection;
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
            {
                throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for handlers.");
            }

            var assemblies = configuration.AssembliesToRegister.Distinct().ToArray();

            foreach (var assembly in assemblies)
            {
                var handlerTypes = assembly.GetTypes()
                    .Where(t => !t.IsAbstract && !t.IsInterface)
                    .SelectMany(t =>
                        t.GetInterfaces()
                         .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                         .Select(i => new { HandlerInterface = i, Implementation = t }));

                foreach (var handler in handlerTypes)
                {
                    services.AddTransient(handler.HandlerInterface, handler.Implementation);
                }
            }

            // Registra o dispatcher em si
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();

            return services;
        }
    }
}
