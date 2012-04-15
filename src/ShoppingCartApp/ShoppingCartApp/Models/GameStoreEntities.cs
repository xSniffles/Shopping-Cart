using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ShoppingCartApp.Models
{
    public class GameStoreEntities : DbContext
    {
        public GameStoreEntities() 
            : base("name=GameStoreModel")
        {}

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<ShoppingCart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        }
    }
