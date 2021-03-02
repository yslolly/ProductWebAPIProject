namespace WebAPIProject.Controllers
{
    public partial class CategoryController
    {
        public class ResponseProductDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public string HiddenCode { get; set; }
        }
    }
}
