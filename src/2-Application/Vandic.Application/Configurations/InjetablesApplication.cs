using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vandic.Application.UserCases.Categories.Queries;
using Vandic.CrossCutting.Meditor.Configurations;

namespace Vandic.Application.Configurations
{
    public static class InjetablesServices
    {
        public static IServiceCollection AddVandicApplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddDispatcher(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(ListCategoryCommand)) ?? default!));

            return services;
        }
    }
}
