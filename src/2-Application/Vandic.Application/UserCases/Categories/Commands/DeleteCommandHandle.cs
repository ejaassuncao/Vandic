using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vandic.Application.Abstracts;
using Vandic.CrossCutting.Meditor.Interfaces;
using Vandic.Data.efcore.Context;
using Vandic.Domain.Enums;
using static Vandic.Application.UserCases.Categories.Events.CategoryAppEvent;

namespace Vandic.Application.UserCases.Categories.Commands
{
    public class DeleteCommandHandle : BaseCommandHandle<DeleteCommand, ResultCommand<bool>>
    {
        public DeleteCommandHandle(AppDbContext appDbContext, IDispatcherCommand commandDispatcher, ILogger<DeleteCommand> logger) : base(appDbContext, commandDispatcher, logger)
        {
        }

        public override async Task<ResultCommand<bool>> HandleAsync(DeleteCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ResultCommand<bool>.Fail("Requisição inválida.");

            try
            {
                var category = await _appDbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (category == null)
                    return ResultCommand<bool>.Fail($"Categoria com Id {request.Id} não encontrada.");

                category.MarkAsDeleted(request.DeletedBy); //Todo: Substituir por usuário logado real

                _appDbContext.Remove(category);

                var success = await _appDbContext.SaveChangesAsync(cancellationToken) > 0;

                if (success)
                {
                    // Evento 1: Log/Auditoria
                    await _commandDispatcher.PublishAsync(new NotifyLogAppEvent(category.Id, request.DeletedBy, EnumStatus.Deleted));

                    // Evento 2: Envio de e-mail
                    await _commandDispatcher.PublishAsync(new SendEmailEvent(category.Id, request.DeletedBy!));
                }

                return success
                    ? ResultCommand<bool>.Ok(true, "Categoria excluída com sucesso.")
                    : ResultCommand<bool>.Fail("Erro ao excluir a categoria.");

            }
            catch (Exception ex)
            {
                // logar se necessário
                return ResultCommand<bool>.FailFromException(ex);
            }
        }
    }


}
