namespace Vandic.CrossCutting.Meditor
{
    public interface IDispatcher
    {
        Task<TResult> SendAsync<TResult>(IRequest<TResult> command, CancellationToken cancellationToken = default);
    }
}
