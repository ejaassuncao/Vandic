using Vandic.MudBlazorServer.Components.Services.Abstraction;

namespace Vandic.MudBlazorServer.Components.Services
{
    public class CategoriaService : BaseService
    {
        protected override string _api { get; set; } = "categorias";

        public CategoriaService(HttpClient httpClient) : base(httpClient) 
        {           
        }
       
    
    }
}
