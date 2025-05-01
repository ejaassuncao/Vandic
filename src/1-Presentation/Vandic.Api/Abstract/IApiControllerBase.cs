using Microsoft.AspNetCore.Mvc;
using Vandic.Application.Abstracts;

namespace Vandic.Api.Abstract
{
    public interface IApiControllerBase
    {
        [HttpGet]
        Task<IActionResult> GetAsync(FilterDto filter);

        [HttpPost]
        Task<IActionResult> PostAsync();

        [HttpPut]
        Task<IActionResult> PutAsync();

        [HttpDelete]
        Task<IActionResult> DeleteAsync();
    }
}
