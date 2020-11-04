using CodingChallenge.Data.Interface;
using CodingChallenge.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Service
{
    public class ShopService : IShopService
    {
        private readonly IOrderDbContext ordersContext;
        private readonly IProductsDbContext productsContext;
        public ShopService(IOrderDbContext ordersContext, IProductsDbContext productsContext)
        {
            this.ordersContext = ordersContext;
            this.productsContext = productsContext;
        }

        #region Products
        public IList<Product> GetAllProducts()
        {
            return productsContext.Products;
        }
        public Product GetProduct(int id)
        {
            return productsContext.Products.FirstOrDefault(x => x.Id.Equals(id));
        }
        public Product CreateProduct(Product product)
        {
            if (product.UnitPrice > 1000) return null;
            if (!productsContext.Products.Any(x => x.Name.Equals(product.Name) || x.Description.Equals(product.Description)))
            {
                int id = productsContext.Products.Max(x => x.Id) + 1; //imitation of db with an autoincrement
                product.Id = id;
                productsContext.Products.Add(product);
                return product;
            }
            return null;
        }
        #endregion

        #region Orders
        public IList<Order> GetAllOrders()
        {
            return ordersContext.Orders;
        }

        public IList<Order> GetAllOrdersWithTotal()
        {
            return ordersContext.Orders.Select(x => OrderTax(x)).ToList();
        }

        public Order CreateNewOrder(Order newOrder)
        {
            if (newOrder != null && newOrder.Products.Count > 0)
            {
                if (HasNotMadeAnOrderToday(newOrder) && InStock(newOrder.Products) && newOrder.GetTotal >= 100)
                {
                    if (PlaceOrder(newOrder))
                    {
                        //faking database index
                        var id = ordersContext.Orders.Max(x => x.Id) + 1;
                        newOrder.Id = id;
                        ordersContext.Orders.Add(newOrder);
                        return OrderTax(newOrder);
                    }
                }

            }
            return null;
        }

        private Order OrderTax(Order order)
        {
            switch (order.CompanyCode)
            {
                case 1:
                    order.Total = (order.GetTotal * 0.02f / 100f) + order.GetTotal;
                    break;
                case 2:
                    order.Total = 1 + order.GetTotal;
                    break;
                default:
                    order.Total = order.GetTotal;
                    break;
            }
            return order;
        }

        private bool PlaceOrder(Order order)
        {
            foreach (var prod in order.Products)
            {
                var stockProd = productsContext.Products.FirstOrDefault(x => x.Id.Equals(prod.Id));
                if (stockProd != null)
                {
                    if (stockProd.StockQuantity >= prod.StockQuantity)
                    {
                        stockProd.StockQuantity -= prod.StockQuantity;
                    }
                    else
                    {
                        return false;//Not Enof Quantity
                    }
                }
                else
                {
                    return false;//Not in stock
                }
            }
            return true;
        }

        private bool HasNotMadeAnOrderToday(Order order)
        {
            return !ordersContext.Orders.Any(x => x.CompanyCode.Equals(order.CompanyCode) && x.Date.Date.Equals(DateTime.Today));
        }

        private bool InStock(IList<Product> products)
        {
            foreach (var prod in products)
            {
                var stockProd = productsContext.Products.FirstOrDefault(x => x.Id.Equals(prod.Id));
                if (stockProd != null)
                {
                    if (stockProd.StockQuantity >= prod.StockQuantity)
                    {
                        continue;
                    }
                    else
                    {
                        return false;//Not Enof Quantity
                    }
                }
                else
                {
                    return false;//Not in stock
                }
            }
            return true;
        }

        #endregion

    }
}
