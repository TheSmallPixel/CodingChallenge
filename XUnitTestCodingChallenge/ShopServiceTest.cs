using CodingChallenge.Data;
using CodingChallenge.Entities;
using CodingChallenge.Service;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace XUnitTestCodingChallenge
{
    public class ShopServiceTest
    {

        [Fact]
        public void TestGetAllOrders()
        {
            var orderContext = new OrderDbContext();
            var prodContext = new ProductsDbContext();
            var shop = new ShopService(orderContext, prodContext);

            Assert.NotNull(shop.GetAllOrders());
        }
        [Fact]
        public void TestGetOrderWithTotal()
        {
            var orderContext = new OrderDbContext();
            var prodContext = new ProductsDbContext();
            var shop = new ShopService(orderContext, prodContext);

            Assert.NotNull(shop.GetAllOrdersWithTotal());
        }
        [Fact]
        public void TestCreateProduct()
        {
            var orderContext = new OrderDbContext();
            var prodContext = new ProductsDbContext();
            var shop = new ShopService(orderContext, prodContext);
            var prod = new Product() { Description = "test01", Name = "Test01", StockQuantity = 100, UnitPrice = 50f };
            Assert.NotNull(shop.CreateProduct(prod));
            Assert.Null(shop.CreateProduct(prod));
            Assert.True(shop.GetAllProducts().Count > 1);
        }
        [Fact]
        public void TestCreateOrder()
        {
            var orderContext = new OrderDbContext();
            var prodContext = new ProductsDbContext();
            var shop = new ShopService(orderContext, prodContext);
            
            //Creo un prodotto
            var prod = new Product() { Description = "test01", Name = "Test01", StockQuantity = 100, UnitPrice = 50f };
            var createProd = shop.CreateProduct(prod);
            Assert.NotNull(createProd);
            //creo un ordine
            var newOrder = shop.CreateNewOrder(new Order() { CompanyCode = 0, Date = DateTime.Now, Products = new List<Product>() { prod } });

            Assert.NotNull(newOrder);
            //provo a rifare l'ordine per verifivare la condizione del giorno
            Assert.Null(shop.CreateNewOrder(newOrder));
            Assert.True(shop.GetAllOrdersWithTotal().Count > 1);
            var gprod = shop.GetProduct(createProd.Id);
            Assert.NotNull(gprod);
            Assert.True(gprod.StockQuantity == 0);
        }
    }
}
