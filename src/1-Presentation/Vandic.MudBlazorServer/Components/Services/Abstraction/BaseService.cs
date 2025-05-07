using System.Text;
using Vandic.Application.Abstracts;
using Vandic.CrossCutting.Resources.Configurations;
namespace Vandic.MudBlazorServer.Components.Services.Abstraction
{
    public abstract class BaseService : IBaseService
    {
        protected abstract string _api { get; set; }
        protected readonly HttpClient _httpClient;

        protected BaseService(HttpClient httpClient)
        {          
            this._httpClient = httpClient;
        }

        public async Task<ResponseQueryDto<T>> GetAllAsync<T>(FilterViewModel<T> param, CancellationToken cancellationToken = default)
        {
            var filter = new FilterDto
            {
                Search = param.Search,
                Page = param.State.Page,
                OrderByName = param.State.SortDefinitions.FirstOrDefault()?.SortBy,
                PageSize = param.State.PageSize,
                OrderByDirection = param.State.SortDefinitions.FirstOrDefault()?.Descending == true ? EnumDirection.Descending : EnumDirection.Ascending
            };

            var url = $"{_api}?Search={filter.Search}&OrderByName={filter.OrderByName}&OrderByDirection={filter.OrderByDirection}&Page={filter.Page}&PageSize={filter.PageSize}";

            using HttpResponseMessage response = await _httpClient.GetAsync(url, cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");

            if (response.Content == null)
                throw new Exception("Response content is null");

            var result = await response.Content.ReadFromJsonAsync<ResponseQueryDto<T>>(cancellationToken);

            if (result == null)
                throw new Exception("Deserialization returned null");

            return result;
        }

        public async Task<string> Create(string objectJson, CancellationToken cancellationToken = default)
        {          
            var content = new StringContent(objectJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_api, content, cancellationToken);

            if (!response.IsSuccessStatusCode || response.Content == null)
            {
                string msg = string.Empty;
                if (response.Content != null)
                {
                    return await response.Content.ReadAsStringAsync();
                }               
            }

            return string.Empty;
        }
               
        public async Task<string> Update(Guid id, string objectJson, CancellationToken cancellationToken = default)
        {
            var content = new StringContent(objectJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(_api, content, cancellationToken);

            if (!response.IsSuccessStatusCode || response.Content == null)
            {
                string msg = string.Empty;
                if (response.Content != null)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return string.Empty;
        }

        public async Task<string> Delete(Guid id, CancellationToken cancellationToken = default)
        {            
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_api}/{id}", cancellationToken);

            if (!response.IsSuccessStatusCode || response.Content == null)
            {
                string msg = string.Empty;
                if (response.Content != null)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
            return string.Empty;
        }
    }
}