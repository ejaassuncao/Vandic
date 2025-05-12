using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vandic.Application.Abstracts;
using Vandic.Application.UserCases.Categories.Commands;
using Vandic.Application.UserCases.Categories.Queries;
using Vandic.CrossCutting.Meditor.Configurations;
using static Vandic.Application.UserCases.Categories.Events.CategoryAppEvent;

namespace Vandic.Test
{
    public class InitDispatcherTest
    {
        private readonly ControllerDispatcherTest controllerDispatcherTest = null;

        public InitDispatcherTest()
        {
            // Configura um provider com o handler necessário
            var services = new ServiceCollection();
            services.AddDispatcher(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(ListCategoryCommand)) ?? default!));

            services.AddSingleton<ControllerDispatcherTest>();

            var serviceProvider = services.BuildServiceProvider();

            controllerDispatcherTest = serviceProvider.GetService<ControllerDispatcherTest>();
        }


        [Fact]         
        public  async Task CreateCommand()
        {
            ResultCommand<bool> result = await controllerDispatcherTest.CreateCommand(new CreateCommand());
            Assert.True(result.Success);
        }


        [Fact]
        public async Task DispararNotificacaoEmail()
        {
            await controllerDispatcherTest.PublicarMsgCategoria(new SendEmailEvent());
            Assert.True(true);
        }
    }
}
