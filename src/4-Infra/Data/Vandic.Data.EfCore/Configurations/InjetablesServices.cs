using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vandic.CrossCutting.Resources.Resources;
using Vandic.Data.efcore.Context;

namespace Vandic.Data.EfCore.Configurations
{
    public static class InjetablesServices
    {
        public static IServiceCollection AddVandicDataEfCore(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            //options.UseLazyLoadingProxies() versao=8.0.1.0
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException($"{Messages.StringConexao} {Messages.NaoEncontrada}")));

            return services;
        }
    }
}
