using Microsoft.EntityFrameworkCore;
using Vandic.Domain.Models.Category.Entitys;

namespace Vandic.Data.efcore.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; } = null!;
    } 
}
