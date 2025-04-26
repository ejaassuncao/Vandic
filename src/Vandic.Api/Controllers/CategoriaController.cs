using Microsoft.AspNetCore.Mvc;
using Vandic.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vandic.Api.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(new List<Categoria>()
            {
                new Categoria { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Nome = "Categoria 1" },
                new Categoria { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Nome = "Categoria 2" },
                new Categoria { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Nome = "Categoria 3" },
                new Categoria { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Nome = "Categoria 4" },
                new Categoria { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Nome = "Categoria 5" },
                new Categoria { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Nome = "Categoria 6" },
                new Categoria { Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), Nome = "Categoria 7" },
                new Categoria { Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), Nome = "Categoria 8" },
                new Categoria { Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), Nome = "Categoria 9" },
                new Categoria { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), Nome = "Categoria 10" },
                new Categoria { Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), Nome = "Categoria 11" },
                new Categoria { Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"), Nome = "Categoria 12" },
                new Categoria { Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"), Nome = "Categoria 13" },
                new Categoria { Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), Nome = "Categoria 14" },
                new Categoria { Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"), Nome = "Categoria 15" },
                new Categoria { Id = Guid.Parse("00000000-0000-0000-0000-000000000000"), Nome = "Categoria 16" },
                new Categoria { Id = Guid.Parse("12345678-1234-1234-1234-123456789012"), Nome = "Categoria 17" },
                new Categoria { Id = Guid.Parse("23456789-2345-2345-2345-234567890123"), Nome = "Categoria 18" },
                new Categoria { Id = Guid.Parse("34567890-3456-3456-3456-345678901234"), Nome = "Categoria 19" },
                new Categoria { Id = Guid.Parse("45678901-4567-4567-4567-456789012345"), Nome = "Categoria 20" },
            });
        }
    }
}
