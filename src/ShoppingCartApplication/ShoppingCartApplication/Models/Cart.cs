using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartApplication.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartID { get; set; }
        public int GameID { get; set; }
        public int ItemsCount { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Game Game { get; set; }
    }
}