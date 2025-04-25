using System.Net.Http.Headers;
using Vandic.MudBlazorServer.Components.Services;
using Vandic.MudBlazorServer.Components.Services.Abstraction;

namespace Vandic.MudBlazorServer.Configurations
{
    public static class VandicServicesExtensions
    {
        public static IServiceCollection AddVandicServices(this IServiceCollection services, IConfiguration config)
        {        
            services.AddHttpClient<CategoriaService>(client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");

                var url = config["BaseUrlApi"] ?? throw new ArgumentNullException("BaseUrlApi", "A chave BaseUrlApi não foi configurada.");
                Uri uri = url.EndsWith("/") ? new Uri(url) : new Uri($"{url}/");                   

                client.BaseAddress = uri;
            });



            return services;
        }
    }
}
