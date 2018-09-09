using OA.Domain.Entities;
using System.Data.Entity;

namespace OA.Infrastructure.DataAccess.Database
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("ShopDatabase")
        {
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
