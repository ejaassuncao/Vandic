using Microsoft.AspNetCore.Mvc;
using Vandic.Application.Abstracts;
using Vandic.Application.UserCases.Categories.Commands;

namespace Vandic.Api.Abstract
{
    public interface IApiControllerBase
    {
        [HttpGet]
        Task<IActionResult> GetAsync(FilterDto filter);

        [HttpPost]
        Task<IActionResult> PostAsync([FromBody] CreateCommand createCommand, CancellationToken cancellationToken);

        [HttpPut]
        Task<IActionResult> PutAsync([FromBody] UpdateCommand updateCommand, CancellationToken cancellationToken);

        [HttpDelete]
        Task<IActionResult> DeleteAsync([FromQuery] Guid Id, CancellationToken cancellationToken);
    }
}
