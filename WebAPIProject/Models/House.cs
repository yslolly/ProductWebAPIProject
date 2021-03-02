using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProject.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public int Price { get; set; }
    }
}
