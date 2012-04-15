using System;

namespace ShoppingCartApp.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public Order OrderID { get; set; }
        public Game GameID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}