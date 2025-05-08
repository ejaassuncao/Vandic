using Vandic.CrossCutting.Meditor.Interfaces;
using static Vandic.Domain.Models.Categories.Events.CategoryEvent;

namespace Vandic.Application.UserCases.Categories.Events
{
    public class CategoryDomainEventHandle
    {
        public class CategoryCreatedEventHandle : IEventHandler<CategoryCreatedEvent>
        {
            public Task HandleAsync(CategoryCreatedEvent evento)
            {
                throw new NotImplementedException();
            }
        }

        public class CategoryUpdatedEventHandle : IEventHandler<CategoryUpdatedEvent>
        {
            public Task HandleAsync(CategoryUpdatedEvent evento)
            {
                throw new NotImplementedException();
            }
        }

        public class CategoryDeletedEventHandle : IEventHandler<CategoryDeletedEvent>
        {
            public Task HandleAsync(CategoryDeletedEvent evento)
            {
                throw new NotImplementedException();
            }
        }
    }
}