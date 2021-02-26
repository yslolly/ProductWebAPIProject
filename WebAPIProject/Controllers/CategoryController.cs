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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("one")]
        public ActionResult<Category> GetCategoryById(int idCategory)
        {
            var category = _categoryService.GetCategoryById(idCategory);
            return Ok(category);
        }

        [HttpGet("all")]
        public ActionResult<List<Category>> GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _categoryService.AddCategory(category);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteCategoryById(int categoryId)
        {
            _categoryService.DeleteCategoryById(categoryId);
            return Ok();
            
        }

        [HttpPut]
        public ActionResult<Category> UpdateCategoryById(int idCategory, Category categoryEditValues)
        {
            var category = _categoryService.UpdateCategoryById(idCategory, categoryEditValues);
            return Ok(category);
        }
    }
}
