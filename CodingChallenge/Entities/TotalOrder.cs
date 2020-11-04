using System.Linq;

namespace CodingChallenge.Entities
{
    public class TotalOrder : Order
    {
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
