using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.Json.Nodes;
using System.Xml;
using Vandic.Api.Abstract;
using Vandic.Application.Abstracts;
using Vandic.Application.UserCases.Category;
using Vandic.CrossCutting.Resources.Configurations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vandic.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase, IApiControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] FilterDto filter)
        {
            await Task.Delay(2000); // Simula um atraso de 2 segundos para fins de demonstração
            List<CategoryDto> categoriesResult = await Task.FromResult(new List<CategoryDto>()
            {
                new CategoryDto { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Category 1" },
                new CategoryDto { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Category 2" },
                new CategoryDto { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Category 3" },
                new CategoryDto { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Category 4" },
                new CategoryDto { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Category 5" },
                new CategoryDto { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Category 6" },
                new CategoryDto { Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), Name = "Category 7" },
                new CategoryDto { Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), Name = "Category 8" },
                new CategoryDto { Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), Name = "Category 9" },
                new CategoryDto { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), Name = "Category 10" },
                new CategoryDto { Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), Name = "Category 11" },
                new CategoryDto { Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"), Name = "Category 12" },
                new CategoryDto { Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"), Name = "Category 13" },
                new CategoryDto { Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), Name = "Category 14" },
                new CategoryDto { Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"), Name = "Category 15" },
                new CategoryDto { Id = Guid.Parse("00000000-0000-0000-0000-000000000000"), Name = "Category 16" },
                new CategoryDto { Id = Guid.Parse("12345678-1234-1234-1234-123456789012"), Name = "Category 17" },
                new CategoryDto { Id = Guid.Parse("23456789-2345-2345-2345-234567890123"), Name = "Category 18" },
                new CategoryDto { Id = Guid.Parse("34567890-3456-3456-3456-345678901234"), Name = "Category 19" },
                new CategoryDto { Id = Guid.Parse("45678901-4567-4567-4567-456789012345"), Name = "Category 20" },
            });

            if (!string.IsNullOrEmpty(filter.Search))
            {
                categoriesResult = categoriesResult.Where(x =>
                               filter.Search.Contains(x.Id.ToString(), StringComparison.OrdinalIgnoreCase) ||
                               filter.Search.Contains(x.Name, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }
            //filtrar dados          
            var totalItems = categoriesResult.Count();

            //Ordenar dados 
            if (!string.IsNullOrEmpty(filter.OrderByName))
            {
                switch (filter.OrderByName)
                {
                    case nameof(CategoryDto.Id):
                        categoriesResult = categoriesResult.OrderByNaturalDirection(
                            filter.OrderByDirection,
                            o => o.Id.ToString()
                        ).ToList();
                        break;
                    case nameof(CategoryDto.Name):
                        categoriesResult = categoriesResult.OrderByNaturalDirection(
                           filter.OrderByDirection,
                           o => o.Name
                       ).ToList();
                        break;
                }
            }
            var pagedData = categoriesResult.Skip(filter.Page * filter.PageSize).Take(filter.PageSize).ToArray();

            return Ok(new ResponseDto<CategoryDto>(pagedData, totalItems));
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
