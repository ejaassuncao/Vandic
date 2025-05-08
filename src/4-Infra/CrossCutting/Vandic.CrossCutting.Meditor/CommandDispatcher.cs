using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vandic.CrossCutting.Meditor.Interfaces;

namespace Vandic.CrossCutting.Meditor
{
    /// <summary>
    /// CommandDispatcher
    /// </summary>
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Dispatcher
        /// </summary>
        /// <param name="serviceProvider"></param>
        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// SendAsync
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<TResult> SendAsync<TResult>(IRequest<TResult> command, CancellationToken cancellationToken = default)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            var handler = _serviceProvider.GetService(handlerType);

            if (handler == null)
                throw new InvalidOperationException($"Handler for command {command.GetType().Name} not found.");

            var method = handlerType.GetMethod("HandleAsync");
            if (method == null)
                throw new InvalidOperationException($"Handle method not found in handler {handlerType.Name}.");

            try
            {
                var task = (Task<TResult>)method.Invoke(handler, [command, cancellationToken]);
                return await task.ConfigureAwait(false);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        /// <summary>
        /// Publish
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task PublishAsync(INotification notification, CancellationToken cancellationToken = default)
        {
            if (notification == null)
                throw new ArgumentNullException(nameof(notification));

            var notificationType = notification.GetType();
            var handlerType = typeof(INotificationHandler<>).MakeGenericType(notificationType);

            var handlers = _serviceProvider.GetServices(handlerType);

            if (handlers == null || !handlers.Any())
                return;

            var handleMethod = handlerType.GetMethod("Handle");

            foreach (var handler in handlers)
            {
                try
                {
                    var task = (Task)handleMethod.Invoke(handler, new object[] { notification, cancellationToken });
                    await task.ConfigureAwait(false);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException ?? ex;
                }
            }
        }

     
        public async Task PublishAsync<T>(T events, CancellationToken cancellationToken = default)
        {
            if (events == null)
                throw new ArgumentNullException(nameof(events));

            var eventsType = events.GetType();
            var handlerType = typeof(IEventHandler<>).MakeGenericType(eventsType);

            var handlers = _serviceProvider.GetServices(handlerType);

            if (handlers == null || !handlers.Any())
                return;

            var handleMethod = handlerType.GetMethod("Handle");

            foreach (var handler in handlers)
            {
                try
                {
                    var task = (Task)handleMethod.Invoke(handler, new object[] { events, cancellationToken });
                    await task.ConfigureAwait(false);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException ?? ex;
                }
            }
        }

    }
}
