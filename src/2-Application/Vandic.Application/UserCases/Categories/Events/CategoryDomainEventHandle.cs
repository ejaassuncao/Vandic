using Vandic.CrossCutting.Meditor.Interfaces;
using static Vandic.Domain.Models.Categories.Events.CategoryEvent;

namespace Vandic.Application.UserCases.Categories.Events
{
    public class CategoryDomainEventHandle
    {
        public class CategoryCreatedEventHandle : INotificationDomainHandler<CategoryCreatedEvent>
        {
            public Task HandleAsync(CategoryCreatedEvent notification, CancellationToken cancellationToken)
            {
               return Task.FromResult("ok");
            }
        }

        public class CategoryUpdatedEventHandle : INotificationDomainHandler<CategoryCreatedEvent>
        {
            public Task HandleAsync(CategoryCreatedEvent notification, CancellationToken cancellationToken)
            {
                return Task.FromResult("ok");
            }
        }

        public class CategoryDeletedEventHandle : INotificationDomainHandler<CategoryCreatedEvent>
        {
            public Task HandleAsync(CategoryCreatedEvent notification, CancellationToken cancellationToken)
            {
                return Task.FromResult("ok");
            }
        }
    }
}