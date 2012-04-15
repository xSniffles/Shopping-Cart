using System;
using System.Collections.Generic;

namespace ShoppingCartApp.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }
}