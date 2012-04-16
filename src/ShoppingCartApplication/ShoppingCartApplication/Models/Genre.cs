using System.Collections.Generic;

namespace ShoppingCartApplication.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }
}