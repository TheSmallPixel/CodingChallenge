using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CompanyCode { get; set; }
        public IList<Product> Products { get; set; }

        public float GetTotal
        {
            get
            {
                return Products.Sum(x => x.StockQuantity * x.UnitPrice);
            }
        }

        public float Total { get; set; }
    }
}
