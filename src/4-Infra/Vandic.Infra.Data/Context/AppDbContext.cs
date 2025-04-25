using Microsoft.EntityFrameworkCore;
using Vandic.Domain.Models;

namespace Vandic.Infra.Data.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; } = null!;
    } 
}
