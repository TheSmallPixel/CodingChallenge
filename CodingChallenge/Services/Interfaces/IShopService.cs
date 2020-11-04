using CodingChallenge.Entities;
using System.Collections.Generic;

namespace CodingChallenge.Service
{
    public interface IShopService
    {
        Order CreateNewOrder(Order newOrder);
        Product CreateProduct(Product product);
        IList<Order> GetAllOrders();
        IList<Order> GetAllOrdersWithTotal();
        IList<Product> GetAllProducts();
        Product GetProduct(int id);
    }
}