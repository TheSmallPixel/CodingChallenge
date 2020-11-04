
using CodingChallenge.Entities;
using System.Collections.Generic;

namespace CodingChallenge.Data.Interface
{
    public interface IOrderDbContext
    {
        IList<Order> Orders { get; set; }
    }
}
