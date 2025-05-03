namespace Vandic.Domain.Abstracts
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public int AlternateId { get; protected set; }

        public string CreatedBy { get; private set; } = string.Empty;
        public string ModifiedBy { get; private set; } = string.Empty;
        public string DeletedBy { get; private set; } = string.Empty;

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        // Domain methods for managing state changes
        public void MarkAsCreated(string user)
        {
            CreatedBy = user;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsModified(string user)
        {
            ModifiedBy = user;
            ModifiedAt = DateTime.UtcNow;
        }

        public void MarkAsDeleted(string user)
        {          
            DeletedBy = user;
            DeletedAt = DateTime.UtcNow;
        }
    }
}
