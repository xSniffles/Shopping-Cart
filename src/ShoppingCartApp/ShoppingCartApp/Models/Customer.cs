using System;
using System.Collections.Generic;

namespace ShoppingCartApp.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }

    }
}