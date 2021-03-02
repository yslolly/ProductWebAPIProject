namespace WebAPIProject.Controllers
{
    public partial class ProductController
    {
        public class CreateProductDTO // DTO = Data Transfer Object
            // hulpclass om de (zelfgekozen, beperkte) data te laten binnenkomen vanuit Swagger naar de controller
        {
            public string Name { get; set; }
            public string HiddenCode { get; set; }
            public int Price { get; set; }
            public int CategoryId { get; set; }
        }
    }
}
