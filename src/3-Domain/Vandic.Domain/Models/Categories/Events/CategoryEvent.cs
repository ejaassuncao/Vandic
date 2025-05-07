using Vandic.Application.Interfaces;

namespace Vandic.Domain.Models.Categories.Events
{
    public class CategoryEvent
    {
        public class CategoryCreatedEvent : IDomainEvent
        {
            private Guid id;
            private string updatedBy;

            public CategoryCreatedEvent(Guid id, string updatedBy)
            {
                this.id = id;
                this.updatedBy = updatedBy;
            }
        }


        public class CategoryUpdatedEvent : IDomainEvent
        {
            private Guid id;
            private string updatedBy;

            public CategoryUpdatedEvent(Guid id, string updatedBy)
            {
                this.id = id;
                this.updatedBy = updatedBy;
            }
        }

        public class CategoryDeletedEvent : IDomainEvent
        {
        }
    }
}
