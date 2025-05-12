using Vandic.Application.Abstracts;
using Vandic.Application.UserCases.Categories.Commands;
using Vandic.Application.UserCases.Categories.Queries;
using Vandic.CrossCutting.Meditor.Interfaces;
using static Vandic.Application.UserCases.Categories.Events.CategoryAppEvent;
namespace Vandic.Test
{
    public class ControllerDispatcherTest
    {
        private readonly IDispatcherCommand _dispatcher;

        public ControllerDispatcherTest(IDispatcherCommand dispatcher)
        {
            _dispatcher = dispatcher;
        }
  
        public async Task<string> ListCategoria(ListCategoryCommand cmd)
        {
                     
            var result = await _dispatcher.SendAsync(cmd);

            return result;          
        }

        public async Task<ResultCommand<bool>> CreateCommand(CreateCommand cmd)
        {
            var result = await _dispatcher.SendAsync(cmd);

            return result;
        }


        public async Task<bool> PublicarMsgCategoria(SendEmailEvent notification)
        {
            await _dispatcher.PublishAsync(notification);

            return true;
        }
    }
}