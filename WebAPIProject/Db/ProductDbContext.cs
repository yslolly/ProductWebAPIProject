using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Models;

namespace WebAPIProject.Db
{
    public class ProductDbContext : DbContext // Microsoft Entity Framework Core installeren
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<CategoriesTotalPrices> CategoriesTotalPrices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) // Microsoft Entity Framework Core SQLite installeren
            => options.UseSqlite("Data Source=products.db"); // db-file: mag eender welke naam zijn (is geen referentie naar tabellen ofzo)
    }
}
