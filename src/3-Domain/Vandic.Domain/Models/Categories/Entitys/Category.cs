using Vandic.Domain.Abstracts;
using static Vandic.Domain.Models.Categories.Events.CategoryEvent;

namespace Vandic.Domain.Models
{
    public class Category : AggregateRoot
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string NameMenu { get; private set; }
        public Guid? CategoryRootId { get; private set; }
        public virtual Category CategoryRoot { get; private set; }
        public virtual ICollection<Category> InverseCategoryRoot { get; private set; } = new List<Category>();

        public Category(
            string name,
            string nameMenu,
            string modifiedBy,
            Guid? categoryRootId = null,
            string? description = null)
        {
            SetProperties(name, nameMenu, categoryRootId, description, modifiedBy);
            AddDomainEvent(new CategoryCreatedEvent(this.Id, modifiedBy));
        }

        public void Update(string name,
            string nameMenu,
            string modifiedBy,
            Guid? categoryRootId = null,
            string? description = null)
        {

            SetProperties(name, nameMenu, categoryRootId, description, modifiedBy);
            AddDomainEvent(new CategoryUpdatedEvent(this.Id, modifiedBy));
        }

        public void UpdateCategoryRoot(Category categoryRoot)
        {
            if (categoryRoot == null) throw new ArgumentNullException(nameof(categoryRoot));

            if (categoryRoot != null && categoryRoot.Id == this.Id)
                throw new InvalidOperationException("Uma categoria não pode ser root dela mesma.");

            CategoryRoot = categoryRoot!;
            CategoryRootId = categoryRoot!.Id;
        }

        private void SetProperties(string name, string nameMenu, Guid? categoryRootId, string? description, string modifiedBy)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");
            if (string.IsNullOrWhiteSpace(nameMenu))
                throw new ArgumentException("NameMenu is required.");

            Name = name;
            NameMenu = string.IsNullOrEmpty(nameMenu) ? name : nameMenu;
            Description = description;
            CategoryRootId = categoryRootId;
            MarkAsModified(modifiedBy);
        }
    }
}
