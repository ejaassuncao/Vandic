using Microsoft.Extensions.DependencyInjection;
using Vandic.CrossCutting.Resources.LocationServices;

namespace Vandic.CrossCutting.Resources.Configurations
{
    public static class ResourcesInjetables
    {
        public static IServiceCollection AddVandicResources(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddScoped<ILocalizationService, LocalizationService>();

            return services;
        }
    }
}
