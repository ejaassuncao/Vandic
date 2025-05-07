using Microsoft.Extensions.Logging;
using Vandic.Application.Abstracts;
using Vandic.CrossCutting.Meditor.Interfaces;
using Vandic.Data.efcore.Context;
using Vandic.Domain.Enums;
using Vandic.Domain.Models.Categories.Entities;
using static Vandic.Application.UserCases.Categories.Events.CategoryAppEvent;

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

            var category = new Category(request.Name, request.NameMenu, request.CreatedBy, request.Description, request.CategoryRootId);

            await _appDbContext.Categories.AddAsync(category, cancellationToken);

            var success = await _appDbContext.SaveChangesAsync(cancellationToken) > 0;

            if (success)
            {
                // Evento 1: Log/Auditoria
                await _commandDispatcher.PublishAsync(new NotifyLogAppEvent(category.Id, request.CreatedBy, EnumStatus.Created));

                // Evento 2: Envio de e-mail
                await _commandDispatcher.PublishAsync(new SendEmailEvent(category.Id, request.CreatedBy));
            }

            return success
                ? ResultCommand<bool>.Ok(true, "Categoria criada com sucesso.")
                : ResultCommand<bool>.Fail("Erro ao salvar a categoria.");
        }
    }
}
