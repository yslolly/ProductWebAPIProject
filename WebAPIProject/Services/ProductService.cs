using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Db;
using WebAPIProject.DTO;
using WebAPIProject.Models;

namespace WebAPIProject.Services
{
    public class ProductService : IProductService
    {
        public void AddProduct(Product product)
        {
            using(var db = new ProductDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public void DeleteProductById(int productId)
        {
            using (var db = new ProductDbContext())
            {
                var product = db.Products.Find(productId);
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var db = new ProductDbContext())
            {
                return db.Products.Include(x=>x.Category).ToList(); // join voor korte weergave categorienaam
            }
        }

        public Product GetProductById(int productId)
        {
            using (var db = new ProductDbContext())
            {
                var product = db.Products.Find(productId); // Find-methode gebeurt op primary key-kolom
                return product;
            }
        }

        public List<Product> GetProductsWithCategories()
        {
            using(var db = new ProductDbContext())
            {
                var productsWithCategories = db.Products.Include(product => product.Category).ToList();
                return productsWithCategories;
            }
        }

        public int GetTotalPrice()
        {
            using (var db = new ProductDbContext())
            {
                int totalPrice = 0;
                var products = db.Products.ToList();
                foreach (var product in products)
                {
                    totalPrice += product.Price;
                }
                return totalPrice;
            }
        }

        public Product UpdateProductById(int idProductToEdit, AddProductDTO productEditValues)
        {
            using (var db = new ProductDbContext())
            {
                var productToEdit = db.Products.Find(idProductToEdit);
                productToEdit.Name = productEditValues.Name;
                productToEdit.Price = productEditValues.Price;
                productToEdit.HiddenCode = productEditValues.HiddenCode;
                productToEdit.CategoryId = productEditValues.CategoryId;
                db.Products.Update(productToEdit);
                db.SaveChanges();
                return productToEdit;
            }
        }
    }
}
