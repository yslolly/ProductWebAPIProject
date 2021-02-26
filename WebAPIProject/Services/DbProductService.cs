using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Db;
using WebAPIProject.Models;

namespace WebAPIProject.Services
{
    public class DbProductService : IProductService
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
                return db.Products.ToList();
            }
        }

        public Product GetProductById(int productId)
        {
            using (var db = new ProductDbContext())
            {
                var product = db.Products.Find(productId);
                return product;
            }
        }

        public Product UpdateProductById(int IdProductToEdit, Product ProductEditValues)
        {
            using (var db = new ProductDbContext())
            {
                var productToEdit = db.Products.Find(IdProductToEdit);
                productToEdit.Name = ProductEditValues.Name;
                productToEdit.Price = ProductEditValues.Price;
                db.Products.Update(productToEdit);
                db.SaveChanges();
                return productToEdit;
            }
        }
    }
}
