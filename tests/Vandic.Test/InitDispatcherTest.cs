using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vandic.Application.UserCases.Categories.Queries;
using Vandic.CrossCutting.Meditor.Configurations;

namespace Vandic.Test
{
    public class InitDispatcherTest
    {
        [Fact]         
        public void Initial()
        {
            // Configura um provider com o handler necessário
            var services = new ServiceCollection();
            services.AddDispatcher(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(ListCategoryCommand)) ?? default!));

            services.AddSingleton<ControllerDispatcherTest>();

            var serviceProvider = services.BuildServiceProvider();

            ControllerDispatcherTest dispatcherTest = serviceProvider.GetService<ControllerDispatcherTest>();
            var result = dispatcherTest.ListCategoria(new ListCategoryCommand()).Result;


            Assert.Equal("Executou o Handle", result);
        }
    }
}
