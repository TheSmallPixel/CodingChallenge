using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingChallenge.Entities;
using CodingChallenge.Helper;
using CodingChallenge.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IShopService shop;

        public ProductsController(IShopService shop)
        {
            this.shop = shop;
        }

        [Authorize]
        [HttpGet("getall")]
        public ActionResult<List<Product>> GetAllProducts(int page, int pageSize)
        {
            return shop.GetAllProducts().Skip(page * pageSize).Take(pageSize).ToList();
        }

        [Authorize]
        [HttpGet]
        public ActionResult<Product> GetProduct(int id)
        {
            var result = shop.GetProduct(id);
            if (result != null)
            {
                return result;
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost("create")]
        public ActionResult<Product> CreateProduct(Product product)
        {
            var result = shop.CreateProduct(product);
            if (result != null)
            {
                return result;
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
