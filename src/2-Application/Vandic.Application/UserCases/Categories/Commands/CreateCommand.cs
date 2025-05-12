using Vandic.Application.Abstracts;

namespace Vandic.Application.UserCases.Categories.Commands
{
    public class CreateCommand : IBaseCommand<bool>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string NameMenu { get;  set; } = string.Empty;
        public Guid? CategoryRootId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;

        public CreateCommand()
        {
            
        }

        public CreateCommand(string name, string description, string nameMenu, Guid? categoryRootId, string createdBy)
        {
            Name = name;
            Description = description;
            NameMenu = nameMenu;
            CategoryRootId = categoryRootId;
            CreatedBy = createdBy;
        }
    }

}
