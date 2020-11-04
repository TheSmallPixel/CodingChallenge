using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Entities;
using CodingChallenge.Helper;
using CodingChallenge.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IShopService shop;

        public OrdersController(IShopService shop)
        {
            this.shop = shop;
        }

        [Authorize]
        [HttpGet("getall")]
        public ActionResult<List<Order>> GetAllOrders(int page, int pageSize)
        {
            return shop.GetAllOrdersWithTotal().Skip(page * pageSize).Take(pageSize).ToList();
        }

        [Authorize]
        [HttpPost("create")]
        public ActionResult<Order> CreateNewOrders(Order newOrder)
        {
            var result =  shop.CreateNewOrder(newOrder);
            if(result != null)
            {
                return result;
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
