using Vandic.Application.Abstracts;
using Vandic.CrossCutting.Meditor.Interfaces;

namespace Vandic.Application.UserCases.Categories.Commands
{
    public class CreateCommand : BaseCommand<bool>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string NameMenu { get;  set; } = string.Empty;
        public Guid? CategoryRootId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }

}
