using Vandic.Application.Interfaces;

namespace Vandic.Domain.Abstracts
{
    public abstract class AggregateRoot : EntityBase
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents;       

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
