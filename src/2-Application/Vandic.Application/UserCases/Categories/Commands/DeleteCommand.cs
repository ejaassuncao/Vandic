using Vandic.Application.Abstracts;
using Vandic.CrossCutting.Meditor.Interfaces;

namespace Vandic.Application.UserCases.Categories.Commands
{
    public class DeleteCommand : BaseCommand<bool>
    {
        public Guid Id { get; set; }
        public string? DeletedBy { get; set; }
    }
}
