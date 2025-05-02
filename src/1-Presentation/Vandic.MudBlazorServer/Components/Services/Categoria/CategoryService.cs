using Vandic.MudBlazorServer.Components.Services.Abstraction;

namespace Vandic.MudBlazorServer.Components.Services
{
    public class CategoryService : BaseService
    {
        protected override string _api { get; set; } = "categories";

        public CategoryService(HttpClient httpClient) : base(httpClient) 
        {           
        }
    }
}