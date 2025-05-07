using Microsoft.EntityFrameworkCore;
using Vandic.Domain.Models.Categories.Entities;

namespace Vandic.Data.efcore.Context
{
    public partial class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;        
    }
}
