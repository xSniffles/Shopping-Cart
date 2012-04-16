
namespace ShoppingCartApplication.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int GameID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Game Game { get; set; }
        public virtual Order Order { get; set; }
    }
}