using CodingChallenge.Data.Interface;
using CodingChallenge.Entities;
using System.Collections.Generic;

namespace CodingChallenge.Data
{
    public class ProductsDbContext : IProductsDbContext
    {
        public IList<Product> Products { get; set; } = new List<Product>();


        public ProductsDbContext()
        {
            Products.Add(new Product() { Id = 0, Name = "Pc", Description = "Hp", StockQuantity = 100, UnitPrice = 500 });
        }
    }
}
