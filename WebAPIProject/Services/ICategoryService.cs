using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Models;

namespace WebAPIProject.Services
{
    public interface ICategoryService
    {
        void AddCategory(Category category); // CREATE
        Category GetCategoryById(int categoryId); // READ
        List<Category> GetAllCategories(); // READ
        Category UpdateCategoryById(int categoryId, Category categoryEditValues); // UPDATE
        void DeleteCategoryById(int categoryId); // DELETE
    }
}
