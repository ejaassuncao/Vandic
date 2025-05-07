using Vandic.CrossCutting.Meditor.Interfaces;
using Vandic.Data.efcore.Context;

namespace Vandic.Application.Abstracts
{
    public abstract class BaseHandle<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : IRequest<TResult> where TResult : new()
    {
        protected readonly AppDbContext _appDbContext;      
              
        protected BaseHandle(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;          
        }

        public abstract Task<TResult> HandleAsync(TCommand request, CancellationToken cancellationToken);
    }
}
