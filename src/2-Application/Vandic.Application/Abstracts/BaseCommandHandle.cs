using Microsoft.Extensions.Logging;
using Vandic.CrossCutting.Meditor.Interfaces;
using Vandic.Data.efcore.Context;

namespace Vandic.Application.Abstracts
{
    public abstract class BaseCommandHandle<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : IRequest<TResult> where TResult : new()    
    {
        protected readonly AppDbContext _appDbContext;
        protected readonly IDispatcherCommand _commandDispatcher;
        protected readonly ILogger<TCommand> _logger;

        protected BaseCommandHandle(AppDbContext appDbContext, IDispatcherCommand commandDispatcher, ILogger<TCommand> logger)
        {
            _appDbContext = appDbContext;
            _commandDispatcher = commandDispatcher;
            _logger = logger;
        }

        public abstract Task<TResult> HandleAsync(TCommand request, CancellationToken cancellationToken);
    }
}
