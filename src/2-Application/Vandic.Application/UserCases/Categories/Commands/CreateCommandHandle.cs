using Microsoft.Extensions.Logging;
using Vandic.Application.Abstracts;
using Vandic.CrossCutting.Meditor.Interfaces;
using Vandic.Data.efcore.Context;
using Vandic.Domain.Models;

namespace Vandic.Application.UserCases.Categories.Commands
{
    public class CreateCommandHandle : BaseHandle<CreateCommand, ResultCommand<bool>>
    {
        public CreateCommandHandle(AppDbContext appDbContext, ICommandDispatcher commandDispatcher, ILogger<CreateCommand> logger) : base(appDbContext, commandDispatcher, logger)
        {
        }

        public override async Task<ResultCommand<bool>> HandleAsync(CreateCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ResultCommand<bool>.Fail("Requisição inválida.");

            var category = new Category(request.Name, request.NameMenu, request.ModifiedBy, request.CategoryRootId, request.Description);
           
            await _appDbContext.Categories.AddAsync(category, cancellationToken);

            var success = await _appDbContext.SaveChangesAsync(cancellationToken) > 0;

            return success
                ? ResultCommand<bool>.Ok(true, "Categoria criada com sucesso.")
                : ResultCommand<bool>.Fail("Erro ao salvar a categoria.");
        }
    }
}
