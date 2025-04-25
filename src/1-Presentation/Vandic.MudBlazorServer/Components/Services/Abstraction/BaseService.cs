using System.Net.Http.Json;
using System.Text;

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

        public async Task<string> GetAllAsync(CancellationToken cancelationToken = default)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync(_api, cancelationToken);

            if (!response.IsSuccessStatusCode)  
                return string.Empty;

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Create(string objectJson, CancellationToken cancelationToken = default)
        {          
            var content = new StringContent(objectJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_api, content, cancelationToken);

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
               
        public async Task<string> Update(Guid id, string objectJson, CancellationToken cancelationToken = default)
        {
            var content = new StringContent(objectJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(_api, content, cancelationToken);

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

        public async Task<string> Delete(Guid id, CancellationToken cancelationToken = default)
        {            
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_api}/{id}", cancelationToken);

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