using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.DTO;
using WebAPIProject.Models;
using WebAPIProject.Services;
using static WebAPIProject.Controllers.CategoryController;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("one")] // READ
        public ActionResult<GetProductDTO> GetProductById(int productId)
        {
            var product = _productService.GetProductById(productId);

            var productDTO = new GetProductDTO();
            productDTO.Id = product.Id;
            productDTO.Name = product.Name;
            productDTO.Price = product.Price;
            productDTO.HiddenCode = product.HiddenCode;
            productDTO.CategoryId = product.CategoryId;

            var categoryDTO = new ResponseCategoryDTO();
            categoryDTO.Id = product.Category.Id;
            categoryDTO.Name = product.Category.Name;
            productDTO.Category = categoryDTO;
            return Ok(productDTO);
        }

        [HttpGet("all without category")] // READ
        public ActionResult<List<ResponseProductDTO>> GetAllProductsWithoutCategory()
        {
            var products = _productService.GetAllProducts();
            List<ResponseProductDTO> productsDTO = new List<ResponseProductDTO>();

            foreach (var product in products)
            {
                var productDTO = new ResponseProductDTO();
                productDTO.Id = product.Id;
                productDTO.Name = product.Name;
                productDTO.Price = product.Price;
                productDTO.HiddenCode = product.HiddenCode;
                productsDTO.Add(productDTO);
            }
            return Ok(productsDTO);
        }

        [HttpGet("products with category")] // READ
        public ActionResult<List<GetProductDTO>> GetProductsWithCategories() // dit datatype, anders endless loop
        {
            var productsWithCategories = _productService.GetProductsWithCategories();
            List<GetProductDTO> productsWithCategoriesDTO = new List<GetProductDTO>();

            foreach (var product in productsWithCategories)
            {
                var productDTO = new GetProductDTO();
                productDTO.Id = product.Id;
                productDTO.Name = product.Name;
                productDTO.Price = product.Price;
                productDTO.HiddenCode = product.HiddenCode;
                productDTO.CategoryId = product.CategoryId;

                var categoryDTO = new ResponseCategoryDTO();
                categoryDTO.Id = product.Category.Id;
                categoryDTO.Name = product.Category.Name;

                productDTO.Category = categoryDTO;

                productsWithCategoriesDTO.Add(productDTO);
            }
            return Ok(productsWithCategoriesDTO);
        }

        [HttpGet("total price")]
        public ActionResult<int> GetTotalPrice()
        {
            var totalPrice = _productService.GetTotalPrice();
            return Ok(totalPrice);
        }
        [HttpPost] // CREATE
        public ActionResult AddProduct(AddProductDTO newProductDTO) 
        {
            var newProduct = new Product();
            newProduct.Name = newProductDTO.Name;
            newProduct.Price = newProductDTO.Price;
            newProduct.HiddenCode = newProductDTO.HiddenCode;
            newProduct.CategoryId = newProductDTO.CategoryId;
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
        public ActionResult<Product> UpdateProductById(int productId, AddProductDTO productEditValues)
        {
            var product = _productService.UpdateProductById(productId, productEditValues);
            product.Name = productEditValues.Name;
            product.Price = productEditValues.Price;
            product.HiddenCode = productEditValues.HiddenCode;
            product.CategoryId = productEditValues.CategoryId;
            return Ok(product);
        }
    }
}
