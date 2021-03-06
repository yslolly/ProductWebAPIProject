﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Db;
using WebAPIProject.DTO;
using WebAPIProject.Models;
using static WebAPIProject.Controllers.CategoryController;

namespace WebAPIProject.Services
{
    public class CategoryService : ICategoryService
    {
        public Category AddCategory(Category category)
        {
            using(var db = new ProductDbContext()) // using met objecten die erven van IDisposable (automatisch sluiten)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return category;
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

        public List<Category> GetAllCategoriesWithProducts()
        {
            using (var db = new ProductDbContext())
            {
                // join als je ook de properties met datatype van andere klasse wil oproepen
                var listOfCategories = db.Categories.Include(x => x.Products).ToList();
                return listOfCategories;
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

        public List<CategoriesTotalPrices> TotalPriceForEveryCategory()
        {
            using (var db = new ProductDbContext())
            {
                var listOfCategories = db.Categories.Include(x => x.Products).ToList();

                var listTotalPrices = new List<CategoriesTotalPrices>();
                foreach (var category in listOfCategories)
                {
                    var totalprice = 0;
                    foreach (var product in category.Products)
                    {
                        totalprice += product.Price;
                    }
                    var newCategoriesTotalPrices = new CategoriesTotalPrices();
                    newCategoriesTotalPrices.Name = category.Name;
                    newCategoriesTotalPrices.totalPrice = totalprice;
                    listTotalPrices.Add(newCategoriesTotalPrices);
                }
                return listTotalPrices;
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
