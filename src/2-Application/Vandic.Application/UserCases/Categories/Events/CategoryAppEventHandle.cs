using Vandic.CrossCutting.Meditor.Interfaces;
using static Vandic.Application.UserCases.Categories.Events.CategoryAppEvent;

namespace Vandic.Application.UserCases.Categories.Events
{
    public class CategoryAppEventHandle
    {

        public class NotifyCategoryUpdatedAppEventHandle : INotificationHandler<NotifyUpdatedAppEvent>
        {
            public async Task HandleAsync(NotifyUpdatedAppEvent notification, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

        public class SendCategoryUpdatedEmailEventHandle : INotificationHandler<SendUpdatedEmailEvent>
        {
            public  async Task HandleAsync(SendUpdatedEmailEvent notification, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
