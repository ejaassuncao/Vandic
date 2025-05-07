namespace Vandic.CrossCutting.Meditor.Interfaces
{
    public interface ICommandDispatcher
    {
        Task<TResult> SendAsync<TResult>(IRequest<TResult> command, CancellationToken cancellationToken = default);
    }
}
