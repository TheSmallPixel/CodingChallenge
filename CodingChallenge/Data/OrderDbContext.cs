
using CodingChallenge.Data.Interface;
using CodingChallenge.Entities;
using System;
using System.Collections.Generic;

namespace CodingChallenge.Data
{
    //Fake Database set
    public class OrderDbContext : IOrderDbContext
    {
        public IList<Order> Orders { get; set; } = new List<Order>();

        public OrderDbContext()
        {
            Orders.Add(new Order()
            {
                Id = 1,
                CompanyCode = 1,
                Date = DateTime.Parse("05/05/2005"),
                Products =
                new List<Product>() {
                new Product() { Id = 0, Name = "Pc", Description = "Hp", StockQuantity = 20, UnitPrice = 500 }
            }
            });
        }
    }
}
