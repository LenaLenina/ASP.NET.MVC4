using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05_Odata.Models
{
    public static class Products
    {
        static List<Product> products = new List<Product>() 
        {
            new Product() { Id = 1, Name = "Car", Price = 15000 },
            new Product() { Id = 2, Name = "Book", Price = 40 },
            new Product() { Id = 3, Name = "Laptop", Price = 1400 },
            new Product() { Id = 4, Name = "Pen", Price = 1 },
            new Product() { Id = 5, Name = "Phone", Price = 4000 },
            new Product() { Id = 6, Name = "House", Price = 120000 }
        };

        public static IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
    }
}