using Vandic.Application.Abstracts;

namespace Vandic.MudBlazorServer.Components.Services.Abstraction
{
    public interface IBaseService
    {
        Task<ResponseDto<T>> GetAllAsync<T>(FilterViewModel<T> filter, CancellationToken cancellationToken = default);
        Task<string> Create(string objectJson, CancellationToken cancellationToken = default);
        Task<string> Update(Guid id, string objectJson, CancellationToken cancellationToken = default);
        Task<string> Delete(Guid id, CancellationToken cancellationToken = default);
    }
}
