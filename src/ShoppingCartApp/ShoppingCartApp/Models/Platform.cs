using System;
using System.Collections.Generic;

namespace ShoppingCartApp.Models
{
    public class Platform
    {
        public int PlatformID { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }

}