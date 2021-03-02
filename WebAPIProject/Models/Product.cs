using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string HiddenCode { get; set; }
        public int CategoryId { get; set; } // naamconventie: verwijzing naar andere class: naam class + "Id"
        // bij andere naam attribuut gebruiken: [ForeignKey("CategoryIdMaarMetAndereNaam"] boven property van andere class plaatsen
        // hier dus :-)
        public Category Category { get; set; }
    }
}
