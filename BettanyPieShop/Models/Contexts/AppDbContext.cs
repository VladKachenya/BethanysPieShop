using Microsoft.EntityFrameworkCore;

namespace BettanyPieShop.Models.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}