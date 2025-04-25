using System.Threading;

namespace Vandic.MudBlazorServer.Components.Services.Abstraction
{
    public interface IBaseService
    {
        Task<string> GetAllAsync(CancellationToken cancelationToken=default);
        Task<string> Create(string objectJson, CancellationToken cancelationToken = default);
        Task<string> Update(Guid id, string objectJson, CancellationToken cancelationToken = default);
        Task<string> Delete(Guid id, CancellationToken cancelationToken = default);
    }
}
