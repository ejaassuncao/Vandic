using System.Xml.Linq;
using Vandic.Domain.Exceptions;

namespace Vandic.Domain.Abstracts
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public int AlternativeId { get; protected set; }

        public string CreatedBy { get; private set; } = string.Empty;
        public string? ModifiedBy { get; private set; }
        public string? DeletedBy { get; private set; }

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        // Domain methods for managing state changes
        protected void MarkAsCreated(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new DomainException("CreatedBy is required.");

            CreatedBy = user;
            CreatedAt = DateTime.UtcNow;
        }

        protected void MarkAsModified(string? user)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new DomainException("ModifiedBy is required.");

            ModifiedBy = user;
            ModifiedAt = DateTime.UtcNow;
        }

        public void MarkAsDeleted(string? user)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new DomainException("DeletedBy is required.");

            DeletedBy = user;
            DeletedAt = DateTime.UtcNow;
        }
    }
}
