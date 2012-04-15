using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartApp.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartID { get; set; }
        public int ItemsCount { get; set; }
        public DateTime DateCreated { get; set; }
        public Game Game { get; set; }
    }
}