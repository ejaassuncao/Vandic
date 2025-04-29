using Microsoft.AspNetCore.Mvc;

namespace Vandic.Api.Abstract
{
    public interface IApiControllerBase
    {
    
        Task<IActionResult> GetAsync();

     
        Task<IActionResult> PostAsync();

        [HttpPut]
        Task<IActionResult> PutAsync();

        [HttpDelete]
        Task<IActionResult> DeleteAsync();
    }
}
