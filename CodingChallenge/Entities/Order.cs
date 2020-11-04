using System;
using System.Collections.Generic;

namespace CodingChallenge.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CompanyCode { get; set; }
        public IList<Product> Products { get; set; }
    }
}
