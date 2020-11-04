using CodingChallenge.Entities;
using System.Collections.Generic;

namespace CodingChallenge.Service
{
    public interface IShopService
    {
        TotalOrder CreateNewOrder(Order newOrder);
        Product CreateProduct(Product product);
        IList<Order> GetAllOrders();
        IList<TotalOrder> GetAllOrdersWithTotal();
        IList<Product> GetAllProducts();
        Product GetProduct(int id);
    }
}