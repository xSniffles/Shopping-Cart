using System.Data.Entity;

namespace ShoppingCartApplication.Models
{
    public class Entities : DbContext
    {
        public Entities() 
            : base("name=Entities")
        {}

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Customer { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        }
    }
