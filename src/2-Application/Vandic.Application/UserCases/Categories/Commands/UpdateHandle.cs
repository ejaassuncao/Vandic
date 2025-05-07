using Microsoft.EntityFrameworkCore;
using Vandic.Application.Abstracts;
using Vandic.Data.efcore.Context;

namespace Vandic.Application.UserCases.Categories.Commands
{
    public class UpdateHandle : BaseHandle<UpdateCommand, ResultCommand<bool>>
    {
        public UpdateHandle(AppDbContext appDbContext) : base(appDbContext) { }

        public override async Task<ResultCommand<bool>> HandleAsync(UpdateCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ResultCommand<bool>.Fail("Requisição inválida.");

            var category = await _appDbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (category == null)
                return ResultCommand<bool>.Fail($"Categoria com Id {request.Id} não encontrada.");

            category.UpdateName(request.Name);
            category.UpdateMenuName(request.NameMenu);
            category.UpdateDescription(request.Description);
            category.MarkAsModified("Usuário Sessao"); //Todo: Substituir por usuário logado real

            // Essa linha geralmente é desnecessária, pois a entidade está sendo trackeada
            // _appDbContext.Entry(category).State = EntityState.Modified;

            var success = await _appDbContext.SaveChangesAsync(cancellationToken) > 0;

            return success
                ? ResultCommand<bool>.Ok(true, "Categoria atualizada com sucesso.")
                : ResultCommand<bool>.Fail("Erro ao atualizar a categoria.");
        }
    }

}
