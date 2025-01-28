using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test1.Services;
using Test1.Models;

namespace Test1.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

    public ProductController(IProductService serv)
    {
    _productService = serv;
    }

[HttpGet]
[Route("getProducts/")]
        public ActionResult<List<Product>> GetProducts()
        {
            try
            {
            var products =  _productService.GetProducts();
            return Ok(products);
            }
            catch (Exception ex)
            {
            return BadRequest(ex.Message);
            }
        }

[HttpPost]
[Route("addProducts/")]
        public ActionResult<Product> AddProducts(Product product)
        {
            try
            {
            _productService.AddProducts(product);
            return Ok($"id = {product.id}");
            }
            catch (Exception ex)
            {
            return BadRequest(ex.Message);
            }
        }
    

[HttpDelete]
[Route("deleteProducts/")]
        public ActionResult<Product> DeleteProducts(int id)
        {
            try
            {
            _productService.DeleteProducts(id);
            return Ok(id);
            }
            catch (Exception ex)
            {
            return BadRequest(ex.Message);
            }
        }

[HttpPut]
[Route("setProducts/")]
        public ActionResult<Product> SetProducts(Product product)
        {
            try
            {
            _productService.SetProducts(product);
            return Ok(product);
            }
            catch (Exception ex)
            {
            return BadRequest(ex.Message);
            }
        }

    }


}