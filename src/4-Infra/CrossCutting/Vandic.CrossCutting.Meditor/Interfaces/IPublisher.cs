namespace Vandic.CrossCutting.Meditor.Interfaces
{
    public interface IPublisher
    {       
        Task PublishAsync(object notification, CancellationToken cancellationToken = default(CancellationToken));               
        Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken)) where TNotification : INotification;
    }
}
