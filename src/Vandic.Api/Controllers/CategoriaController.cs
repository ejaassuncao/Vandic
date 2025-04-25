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
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 1" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 2" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 3" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 4" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 5" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 6" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 7" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 8" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 9" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 10" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 11" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 12" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 13" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 14" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 15" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 16" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 17" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 18" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 19" },
                new Categoria { Id = Guid.NewGuid(), Nome = "Categoria 20" },
            });
        }
    }
}
