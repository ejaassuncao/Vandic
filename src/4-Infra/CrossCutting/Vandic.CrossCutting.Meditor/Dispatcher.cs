using System.Reflection;

namespace Vandic.CrossCutting.Meditor
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Dispatcher
        /// </summary>
        /// <param name="serviceProvider"></param>
        public Dispatcher(IServiceProvider serviceProvider)
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
        }
}
