using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vandic.Api.Abstract;
using Vandic.Application.Abstracts;
using Vandic.Application.UserCases.Categories.Commands;
using Vandic.CrossCutting.Meditor.Interfaces;
using Vandic.CrossCutting.Resources.Configurations;
using Vandic.Data.efcore.Context;
using Vandic.Domain.Models;
using Vandic.Domain.Models.Categories.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vandic.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase, IApiControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(AppDbContext appDbContext, ICommandDispatcher commandDispatcher, ILogger<CategoryController> logger)
        {
            _appDbContext = appDbContext;
            _commandDispatcher = commandDispatcher;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] FilterDto filter)
        {
            IQueryable<Category> categoryQuery = _appDbContext.Categories.AsNoTracking();

            if (!string.IsNullOrEmpty(filter.Search))
            {
                var search = filter.Search.Trim();
                categoryQuery = categoryQuery.Where(x =>
                    x.Id.ToString().Contains(search) ||
                    x.Name.Contains(search)
                );
            }

            if (!string.IsNullOrEmpty(filter.OrderByName))
            {
                switch (filter.OrderByName)
                {
                    case nameof(Category.Id):
                        categoryQuery = categoryQuery.OrderByNaturalDirection(filter.OrderByDirection, x => x.Id.ToString());
                        break;
                    case nameof(Category.Name):
                        categoryQuery = categoryQuery.OrderByNaturalDirection(filter.OrderByDirection, x => x.Name);
                        break;
                }
            }

            return Ok(await Task.FromResult(new ResponseQueryDto<Category>(categoryQuery, filter)));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCommand command, CancellationToken cancellationToken)
            => await HandleCommandAsync(command, cancellationToken);

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdateCommand command, CancellationToken cancellationToken)
            => await HandleCommandAsync(command, cancellationToken);

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteCommand { Id = id };
            return await HandleCommandAsync(command, cancellationToken);
        }

        // Método privado genérico reutilizável
        private async Task<IActionResult> HandleCommandAsync<TResponse>(BaseCommand<TResponse> command, CancellationToken cancellationToken)
            where TResponse : new()
        {
            try
            {
                var result = await _commandDispatcher.SendAsync(command, cancellationToken);

                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar comando {@Command}", command);
                var failResult = ResultCommand<TResponse>.FailFromException(ex);
                return StatusCode(500, failResult);
            }
        }
    }


}
