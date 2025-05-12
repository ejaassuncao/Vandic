namespace Vandic.CrossCutting.Meditor.Interfaces
{
    public interface INotificationHandler<in TNotification> where TNotification :INotification
    {
        Task HandleAsync(TNotification notification, CancellationToken cancellationToken);
    }


    public interface INotificationDomainHandler<in TNotificationDomain> where TNotificationDomain : class
    {
        Task HandleAsync(TNotificationDomain notification, CancellationToken cancellationToken);
    }
}
