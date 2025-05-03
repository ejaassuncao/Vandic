using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vandic.Api.Abstract;
using Vandic.Application.Abstracts;
using Vandic.CrossCutting.Resources.Configurations;
using Vandic.Data.efcore.Context;
using Vandic.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vandic.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase, IApiControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] FilterDto filter)
        {
            IQueryable<Category> categoryQuery = _appDbContext.Categories.AsNoTracking();

            if (!string.IsNullOrEmpty(filter.Search))
            {
                var seach = filter.Search.Trim();
                categoryQuery = categoryQuery.Where(x =>
                               x.Id.ToString().Contains(seach) ||
                               x.Name.Contains(seach)
                );
            }              
            //Ordenar dados       
            if (!string.IsNullOrEmpty(filter.OrderByName))
            {
                switch (filter.OrderByName)
                {
                    case nameof(Category.Id):
                        categoryQuery = categoryQuery.OrderByNaturalDirection(
                            filter.OrderByDirection,
                            o => o.Id.ToString()
                        );
                        break;
                    case nameof(Category.Name):
                        categoryQuery = categoryQuery.OrderByNaturalDirection(
                           filter.OrderByDirection,
                           o => o.Name
                       );
                        break;
                }
            }

            return Ok(new ResponseDto<Category>(categoryQuery, filter));
        }

        public Task<IActionResult> PostAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> PutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteAsync()
        {
            throw new NotImplementedException();
        }
                
    }
}
