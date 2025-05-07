using Vandic.CrossCutting.Meditor.Interfaces;

namespace Vandic.Application.UserCases.Categories.Queries
{
    public class ListCategoryHandler : IRequestHandler<ListCategoryCommand, string>
    {
        public async Task<string> HandleAsync(ListCategoryCommand request, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult("Executou o Handle");
        }
    }
}