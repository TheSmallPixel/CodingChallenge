
using CodingChallenge.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Interface
{
    public interface IProductsDbContext
    {
        IList<Product> Products { get; set; }
    }
}
