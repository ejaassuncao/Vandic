using Vandic.Application.Abstracts;

namespace Vandic.Application.UserCases.Categories.Commands
{
    public class UpdateCommand : BaseCommand<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string NameMenu { get; set; }

        public Guid? CategoryRootId { get; set; }
        public string ModifiedBy { get; set; }
    }

}
