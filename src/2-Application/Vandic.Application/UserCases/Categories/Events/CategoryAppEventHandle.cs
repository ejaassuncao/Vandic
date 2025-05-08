using Vandic.CrossCutting.Meditor.Interfaces;
using static Vandic.Application.UserCases.Categories.Events.CategoryAppEvent;
using static Vandic.Domain.Models.Categories.Events.CategoryEvent;

namespace Vandic.Application.UserCases.Categories.Events
{
    public class CategoryAppEventHandle
    {

        public class NotifyCategoryUpdatedAppEventHandle : INotificationHandler<NotifyLogAppEvent>
        {           
            public Task HandleAsync(NotifyLogAppEvent notification, CancellationToken cancellationToken)
            {
                //todo: gerar log de auditoria
                throw new NotImplementedException();
            }
        }

        public class SendCategoryUpdatedEmailEventHandle : INotificationHandler<SendEmailEvent>
        {
            public  async Task HandleAsync(SendEmailEvent notification, CancellationToken cancellationToken)
            {
                //todo: enviar email de notificação
                throw new NotImplementedException();
            }
        }
    }
}
