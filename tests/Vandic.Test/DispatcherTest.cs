using Vandic.Application.UserCases.Category.Commands;
using Vandic.CrossCutting.Meditor;
namespace Vandic.Test
{
    public class DispatcherTest
    {
        private readonly IDispatcher _dispatcher;

        public DispatcherTest(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
  
        public async Task Execute()
        {
            var cmd = new ListCategoriaCommand();
                     
            var result = await _dispatcher.SendAsync<string>(cmd);

            Assert.Equal("executou o Handle", result);
        }
    }
}