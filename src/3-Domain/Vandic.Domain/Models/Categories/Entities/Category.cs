using Vandic.Domain.Abstracts;
using Vandic.Domain.Exceptions;
using static Vandic.Domain.Models.Categories.Events.CategoryEvent;

namespace Vandic.Domain.Models.Categories.Entities
{
    public class Category : AggregateRoot
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string NameMenu { get; private set; }
        public Guid? CategoryRootId { get; private set; }
        public virtual Category CategoryRoot { get; private set; }
        public virtual ICollection<Category> InverseCategoryRoot { get; private set; } = new List<Category>();

        public Category()
        {
            
        }
       
        public void Create(
            string name,
            string nameMenu,
            string createddBy,
            string? description = null,
            Guid? categoryRootId = null)
        {
            SetProperties(name, nameMenu, categoryRootId, description);
            MarkAsCreated(createddBy);
            AddDomainEvent(new CategoryCreatedEvent(this.Id, createddBy));
        }

        public void Update(string name,
            string nameMenu,
            string modifiedBy,
            string? description = null,
            Guid? categoryRootId = null)
        {
            SetProperties(name, nameMenu, categoryRootId, description);
            MarkAsModified(modifiedBy);
            AddDomainEvent(new CategoryUpdatedEvent(this.Id, modifiedBy));
        }

        public void UpdateCategoryRoot(Category categoryRoot)
        {
            if (categoryRoot == null) throw new DomainException(nameof(categoryRoot));

            if (categoryRoot != null && categoryRoot.Id == this.Id)
                throw new DomainException("Uma categoria não pode ser root dela mesma.");

            CategoryRoot = categoryRoot!;
            CategoryRootId = categoryRoot!.Id;
        }

        private void SetProperties(string name, string nameMenu, Guid? categoryRootId, string? description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name is required.");
         
            Name = name;
            NameMenu = string.IsNullOrEmpty(nameMenu) ? name : nameMenu;
            Description = description;
            CategoryRootId = categoryRootId;           
        }
    }
}
