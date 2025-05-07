using Vandic.Application.Abstracts;
using Vandic.CrossCutting.Meditor.Interfaces;

namespace Vandic.Application.UserCases.Categories.Commands
{
    public class CreateCommand : BaseCommand<bool>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string NameMenu { get; internal set; }
        public Guid? CategoryRootId { get; internal set; }
    }

}
