using Vandic.Application.Abstracts;
using Vandic.CrossCutting.Meditor.Interfaces;

namespace Vandic.Application.UserCases.Categories.Commands
{
    public class DeleteCommand : IBaseCommand<bool>
    {
        public Guid Id { get; set; }
        public string? DeletedBy { get; set; }
    }
}
