using Microsoft.EntityFrameworkCore;
using Vandic.Application.Abstracts;
using Vandic.Data.efcore.Context;

namespace Vandic.Application.UserCases.Categories.Commands
{
    public class DeleteHandle : BaseHandle<DeleteCommand, ResultCommand<bool>>
    {
        public DeleteHandle(AppDbContext appDbContext) : base(appDbContext) { }

        public override async Task<ResultCommand<bool>> HandleAsync(DeleteCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ResultCommand<bool>.Fail("Requisição inválida.");

            var category = await _appDbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (category == null)
                return ResultCommand<bool>.Fail($"Categoria com Id {request.Id} não encontrada.");

            category.MarkAsDeleted("Usuário da sessão"); //Todo: Substituir por usuário logado real

            _appDbContext.Remove(category);

            var success = await _appDbContext.SaveChangesAsync(cancellationToken) > 0;

            return success
                ? ResultCommand<bool>.Ok(true, "Categoria excluída com sucesso.")
                : ResultCommand<bool>.Fail("Erro ao excluir a categoria.");
        }
    }


}
