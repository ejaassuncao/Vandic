using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vandic.Application.UserCases.Category.Commands;
using Vandic.CrossCutting.Meditor;

namespace Vandic.Test
{
    public class InitDispatcherTest
    {
        [Fact]         
        public void Initital()
        {
            // Configura um provider com o handler necessário
            var services = new ServiceCollection();
            services.AddDispatcher(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(ListCategoriaCommand)) ?? default!));

            services.AddSingleton<DispatcherTest>();

            var serviceProvider = services.BuildServiceProvider();

            DispatcherTest dispatcherTest = serviceProvider.GetService<DispatcherTest>();
            dispatcherTest.Execute().Wait();
        }
    }
}
