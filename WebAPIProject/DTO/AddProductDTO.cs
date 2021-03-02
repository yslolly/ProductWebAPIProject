using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProject.DTO
{
    public class AddProductDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string HiddenCode { get; set; }
        public int CategoryId { get; set; }
    }
}
