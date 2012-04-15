using System;

namespace ShoppingCartApp.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public string Title { get; set; }
        public int PlatformID { get; set; }
        public int GenreID { get; set; }
        public decimal Price { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public Platform Platform { get; set; }
        public Genre Genre { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
    }
}