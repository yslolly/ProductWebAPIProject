using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Models;
using WebAPIProject.Services;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("one")] // READ
        public ActionResult<Product> GetProductById(int productId)
        {
            var product = _productService.GetProductById(productId);
            return Ok(product);
        }

        [HttpGet("all")] // READ
        public ActionResult<List<Product>> GetAllProduct()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("products and categories")] // READ
        public ActionResult<List<Product>> GetProductsWithCategories()
        {
            var productsWithCategories = _productService.GetProductsWithCategories();
            return Ok(productsWithCategories);
        }

        [HttpGet("total price")]
        public ActionResult<int> GetTotalPrice()
        {
            var totalPrice = _productService.GetTotalPrice();
            return Ok(totalPrice);
        }
        [HttpPost] // CREATE
        public ActionResult AddProduct(Product newProduct)
        {
            _productService.AddProduct(newProduct);
            return Ok();
        }

        [HttpDelete] // DELETE
        public ActionResult DeleteProductById(int productId)
        {
            _productService.DeleteProductById(productId);
            return Ok();
        }

        [HttpPut] // UPDATE
        public ActionResult<Product> UpdateProductById(int productId, Product productEditValues)
        {
            var product = _productService.UpdateProductById(productId, productEditValues);
            return Ok(product);
        }
    }
}
