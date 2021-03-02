using System.Collections.Generic;

namespace WebAPIProject.Controllers
{
    public partial class CategoryController
    {
        public class ResponseCategoryWithProductsDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<ResponseProductDTO> Products { get; set; }
        }
    }
}
