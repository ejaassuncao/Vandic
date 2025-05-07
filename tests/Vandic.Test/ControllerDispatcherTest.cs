using Vandic.Application.UserCases.Categories.Queries;
using Vandic.CrossCutting.Meditor.Interfaces;
namespace Vandic.Test
{
    public class ControllerDispatcherTest
    {
        private readonly ICommandDispatcher _dispatcher;

        public ControllerDispatcherTest(ICommandDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
  
        public async Task<string> ListCategoria(ListCategoryCommand cmd)
        {
                     
            var result = await _dispatcher.SendAsync<string>(cmd);

            return result;          
        }
    }
}