using Vandic.Domain.Abstracts;

namespace Vandic.Domain.Models.Category
{
    public class Category : AggregateRoot
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string NameMenu { get; private set; }
        public Guid? CategoriaRootId { get; private set; }
        public virtual Category CategoriaRoot { get; private set; }

        public Category(string name, string nameMenu, Guid? categoryRootId = null, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");
            if (string.IsNullOrWhiteSpace(nameMenu))
                throw new ArgumentException("NameMenu is required.");

            Name = name;
            NameMenu = nameMenu;
            Description = description;
            CategoriaRootId = categoryRootId;
        }

        public void SetCategoryRoot(Category root)
        {
            CategoriaRoot = root ?? throw new ArgumentNullException(nameof(root));
            CategoriaRootId = root.Id;
        }
    }

}
