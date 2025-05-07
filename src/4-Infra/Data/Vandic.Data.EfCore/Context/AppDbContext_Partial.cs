using Microsoft.EntityFrameworkCore;
using Vandic.Domain.Models;

namespace Vandic.Data.efcore.Context
{
    public partial class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;        
    }
}
