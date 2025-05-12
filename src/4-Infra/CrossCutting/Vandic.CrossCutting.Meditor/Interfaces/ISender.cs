namespace Vandic.CrossCutting.Meditor.Interfaces
{
    public interface ISender
    {
        Task<TResult> SendAsync<TResult>(IRequest<TResult> command, CancellationToken cancellationToken = default);        
    }
}
