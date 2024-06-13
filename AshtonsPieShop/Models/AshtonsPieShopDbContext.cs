using Microsoft.EntityFrameworkCore;

namespace AshtonsPieShop.Models
{
    public class AshtonsPieShopDbContext : DbContext
    {
        public AshtonsPieShopDbContext(DbContextOptions<AshtonsPieShopDbContext>
            options) : base(options)
            {
            }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
    }
}
