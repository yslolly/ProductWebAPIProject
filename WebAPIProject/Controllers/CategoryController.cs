using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.DTO;
using WebAPIProject.Models;
using WebAPIProject.Services;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) // constructor injection
        {
            _categoryService = categoryService; // via menu: create and assign ...
        }

        [HttpGet("one")]
        public ActionResult<ResponseCategoryWithProductsDTO> GetCategoryById(int idCategory) // todo: hier id verbergen bij weergave resultaat of niet?
        {
            var category = _categoryService.GetCategoryById(idCategory);

            var responseCategoryDTO = new ResponseCategoryWithProductsDTO();
            responseCategoryDTO.Id = category.Id;
            responseCategoryDTO.Name = category.Name;
            
            var listOfProductsDTO = new List<ResponseProductDTO>();
            foreach (var product in responseCategoryDTO.Products)
            {
                var productDTO = new ResponseProductDTO();
                productDTO.Id = product.Id;
                productDTO.Name = product.Name;
                productDTO.Price = product.Price;
                listOfProductsDTO.Add(productDTO);
            }
            responseCategoryDTO.Products = listOfProductsDTO;
            return Ok(responseCategoryDTO);
        }

        [HttpGet("all")]
        public ActionResult<List<ResponseCategoryDTO>> GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            var listOfResponseCategoryDTO = new List<ResponseCategoryDTO>();
            foreach (var category in categories)
            {
                var responseCategoryDTO = new ResponseCategoryDTO();
                responseCategoryDTO.Id = category.Id;
                responseCategoryDTO.Name = category.Name;
                listOfResponseCategoryDTO.Add(responseCategoryDTO);
            }
            return Ok(listOfResponseCategoryDTO);
        }

        [HttpGet("all with products")]
        public ActionResult<List<ResponseCategoryWithProductsDTO>> GetCategoriesWithProducts() // join tussen Category en Products gebeurt met Include
        {
            var categories = _categoryService.GetAllCategoriesWithProducts();
            var listOfResponseCategoryDTO = new List<ResponseCategoryWithProductsDTO>();
            foreach (var category in categories) // deze dubbele foreach-loop kan je in 1 lijn oplossen (zie later met NuGet Package)
            { // kan met dubbele foreach loop, met 2 LINQ expresssies met select (ingewikkeld) of automapper (NuGet)
                var responseCategoryDTO = new ResponseCategoryWithProductsDTO();
                responseCategoryDTO.Id = category.Id;
                responseCategoryDTO.Name = category.Name;
                responseCategoryDTO.Products = new List<ResponseProductDTO>();
                foreach (var product in category.Products)
                {
                    var responseProductDTO = new ResponseProductDTO();
                    responseProductDTO.Id = product.Id;
                    responseProductDTO.Name = product.Name;
                    responseProductDTO.Price = product.Price;
                    responseProductDTO.HiddenCode = product.HiddenCode;
                    responseCategoryDTO.Products.Add(responseProductDTO);
                }
                listOfResponseCategoryDTO.Add(responseCategoryDTO);
            }
            return Ok(listOfResponseCategoryDTO);
        }

        [HttpGet("total price for every category")]
        public ActionResult <List<CategoriesTotalPrices>> GetTotalPriceForEveryCategory()
        {
            var listOfCategoriesAndTotalPrices = _categoryService.TotalPriceForEveryCategory();
            return Ok(listOfCategoriesAndTotalPrices);

        }

        [HttpPost]
        public ActionResult<Category> AddCategory(CreateCategoryDTO addCategoryDTO) // mag ook gewoon met een void
            // met <Category> return krijgen we in Swagger gewoon meer info mee na execute (dus bv. link naar juiste categorie)
        {
            var newCategory = new Category();
            newCategory.Name = addCategoryDTO.Name;
            _categoryService.AddCategory(newCategory);
            return Ok();
        }
                
        [HttpDelete]
        public ActionResult DeleteCategoryById(int categoryId)
        {
            _categoryService.DeleteCategoryById(categoryId);
            return Ok();
        }

        [HttpPut]
        public ActionResult<Category> UpdateCategoryById(int idCategory, CreateCategoryDTO categoryEditValues)
        {
            var updatedCategory = new Category();
            updatedCategory.Name = categoryEditValues.Name;
            var category = _categoryService.UpdateCategoryById(idCategory, updatedCategory);
            return Ok(category);
        }
    }
}
