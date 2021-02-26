using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Models;

namespace WebAPIProject.Services
{
    public interface IProductService
    {
        void AddProduct(Product product); // CREATE
        Product GetProductById(int productId); // READ
        List<Product> GetAllProducts();
        Product UpdateProductById(int IdProductToEdit, Product updatedProduct); // UPDATE
        void DeleteProductById(int productId); // DELETE
    }
}
