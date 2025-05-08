namespace Vandic.CrossCutting.Meditor.Interfaces
{
    public interface IEventHandler<T> where T : class
    {
        Task HandleAsync(T evento);
    }
}
