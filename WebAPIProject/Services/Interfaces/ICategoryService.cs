using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.DTO;
using WebAPIProject.Models;

namespace WebAPIProject.Services
{
    public interface ICategoryService
    {
        Category AddCategory(Category category); // CREATE
        Category GetCategoryById(int categoryId); // READ
        List<Category> GetAllCategories(); // READ
        List<CategoriesTotalPrices> TotalPriceForEveryCategory(); // READ
        public List<Category> GetAllCategoriesWithProducts();
        Category UpdateCategoryById(int categoryId, Category categoryEditValues); // UPDATE
        void DeleteCategoryById(int categoryId); // DELETE
    }
}
