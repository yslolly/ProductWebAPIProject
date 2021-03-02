using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Models;
using static WebAPIProject.Controllers.CategoryController;

namespace WebAPIProject.DTO
{
    public class GetProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string HiddenCode { get; set; }
        public int CategoryId { get; set; }
        public ResponseCategoryDTO Category { get; set;}
    }
}
