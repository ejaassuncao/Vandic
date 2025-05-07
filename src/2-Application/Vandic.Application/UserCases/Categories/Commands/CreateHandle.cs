using Vandic.Application.Abstracts;
using Vandic.Data.efcore.Context;
using Vandic.Domain.Models;

namespace Vandic.Application.UserCases.Categories.Commands
{
    public class CreateHandle : BaseHandle<CreateCommand, ResultCommand<bool>>
    {
        public CreateHandle(AppDbContext appDbContext) : base(appDbContext) { }

        public override async Task<ResultCommand<bool>> HandleAsync(CreateCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ResultCommand<bool>.Fail("Requisição inválida.");

            var category = new Category(request.Name, request.NameMenu, request.CategoryRootId, request.Description);
            category.MarkAsCreated("Usuário Sessao");  //Todo: Substituir por usuário logado real

            await _appDbContext.Categories.AddAsync(category, cancellationToken);

            var success = await _appDbContext.SaveChangesAsync(cancellationToken) > 0;

            return success
                ? ResultCommand<bool>.Ok(true, "Categoria criada com sucesso.")
                : ResultCommand<bool>.Fail("Erro ao salvar a categoria.");
        }
    }
}
