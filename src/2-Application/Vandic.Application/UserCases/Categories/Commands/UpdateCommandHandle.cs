using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vandic.Application.Abstracts;
using Vandic.CrossCutting.Meditor.Interfaces;
using Vandic.Data.efcore.Context;
using Vandic.Domain.Enums;
using static Vandic.Application.UserCases.Categories.Events.CategoryAppEvent;

namespace Vandic.Application.UserCases.Categories.Commands
{
    public class UpdateCommandHandle : BaseCommandHandle<UpdateCommand, ResultCommand<bool>>
    {
        public UpdateCommandHandle(AppDbContext appDbContext, IDispatcherCommand commandDispatcher, ILogger<UpdateCommand> logger) : base(appDbContext, commandDispatcher, logger)
        {
        }
        
        public override async Task<ResultCommand<bool>> HandleAsync(UpdateCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ResultCommand<bool>.Fail("Requisição inválida.");
            try
            {
                var category = await _appDbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (category == null)
                    return ResultCommand<bool>.Fail($"Categoria com Id {request.Id} não encontrada.");

                category.Update(request.Name, request.NameMenu, request.ModifiedBy, request.Description, request.CategoryRootId);

                var success = await _appDbContext.SaveChangesAsync(cancellationToken) > 0;


                if (success)
                {
                    // Evento 1: Log/Auditoria
                    await _commandDispatcher.PublishAsync(new NotifyLogAppEvent(category.Id, request.ModifiedBy, EnumStatus.Updated));

                    // Evento 2: Envio de e-mail
                    await _commandDispatcher.PublishAsync(new SendEmailEvent(category.Id, request.Name));
                }


                return success
                    ? ResultCommand<bool>.Ok(true, "Categoria atualizada com sucesso.")
                    : ResultCommand<bool>.Fail("Erro ao atualizar a categoria.");

            }
            catch (Exception ex)
            {
                // logar se necessário
                return ResultCommand<bool>.FailFromException(ex);
            }
        }
    }

}
