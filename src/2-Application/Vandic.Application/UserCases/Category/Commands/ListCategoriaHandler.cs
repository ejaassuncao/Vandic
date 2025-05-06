using Vandic.CrossCutting.Meditor;

namespace Vandic.Application.UserCases.Category.Commands
{
    public class ListCategoriaHandler : IRequestHandler<ListCategoriaCommand, string>
    {
        public async Task<string> HandleAsync(ListCategoriaCommand request, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult("executou o Handle");
        }
    }
}