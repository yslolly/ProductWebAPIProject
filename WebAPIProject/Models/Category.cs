using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPIProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // [JsonIgnore] // dit lost het probleem van de oneindige loop niet op
        public List<Product> Products { get; set; } // 1-to-many relationship between category and product
        // geeft oneindige loop in json -- oplossing: https://stackoverflow.com/questions/65163728/how-to-json-serialize-without-cyclic-error 
    }
}
