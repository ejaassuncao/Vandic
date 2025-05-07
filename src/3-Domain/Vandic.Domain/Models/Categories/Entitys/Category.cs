using Vandic.Domain.Abstracts;

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
            Guid? categoryRootId = null,
            string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");
            if (string.IsNullOrWhiteSpace(nameMenu))
                throw new ArgumentException("NameMenu is required.");

            Name = name;
            NameMenu = string.IsNullOrEmpty(nameMenu) ? name : nameMenu;
            Description = description;
            CategoryRootId = categoryRootId;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");

            Name = name;
        }

        public void UpdateMenuName(string nameMenu)
        {
            if (string.IsNullOrWhiteSpace(nameMenu))
                throw new ArgumentException("NameMenu is required.");

            NameMenu = nameMenu;
        }

        public void UpdateDescription(string description)
        {
            Description = string.IsNullOrWhiteSpace(description) ? null : description;
        }

        public void UpdateCategoryRoot(Category root)
        {
            CategoryRoot = root ?? throw new ArgumentNullException(nameof(root));
            CategoryRootId = root.Id;
        }
    }

}
