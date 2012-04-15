using System;
using System.Collections.Generic;

namespace ShoppingCartApp.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public Game Game { get; set; }
        public Customer CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}