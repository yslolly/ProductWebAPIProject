using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Db;
using WebAPIProject.Models;

namespace WebAPIProject.Services
{
    public class CategoryService : ICategoryService
    {
        public void AddCategory(Category category)
        {
            using(var db = new ProductDbContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void DeleteCategoryById(int categoryId)
        {
            using (var db = new ProductDbContext())
            {
                var category = db.Categories.Find(categoryId);
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }

        public List<Category> GetAllCategories()
        {
            using (var db = new ProductDbContext())
            {
                return db.Categories.ToList();
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            using (var db = new ProductDbContext())
            {
                var category = db.Categories.Find(categoryId);
                return category;
            }
        }

        public Category UpdateCategoryById(int categoryId, Category categoryEditValues)
        {
            using (var db = new ProductDbContext())
            {
                var categoryToEdit = db.Categories.Find(categoryId);
                categoryToEdit.Name = categoryEditValues.Name;
                db.Categories.Update(categoryToEdit);
                db.SaveChanges();
                return categoryToEdit;
            }
        }
    }
}
