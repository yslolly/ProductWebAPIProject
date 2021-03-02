using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.DTO;
using WebAPIProject.Models;

namespace WebAPIProject.Services
{
    public interface IProductService
    {
        void AddProduct(Product product); // CREATE
        Product GetProductById(int productId); // READ
        List<Product> GetAllProducts(); // READ
        int GetTotalPrice(); // READ
        List<Product> GetProductsWithCategories(); // READ
        Product UpdateProductById(int IdProductToEdit, AddProductDTO updatedProduct); // UPDATE
        void DeleteProductById(int productId); // DELETE
    }
}
