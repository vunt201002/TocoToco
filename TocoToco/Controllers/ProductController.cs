using TocoToco.Base;
using TocoToco.BL.DTOs.ProductDTOs;
using TocoToco.BL.Services.ProductService;

namespace TocoToco.Controllers
{
    public class ProductController : BaseController<ProductDTO, ProductCreateDTO, ProductUpdateDTO>
    {
        public ProductController(IProductService productService) : base(productService)
        {
            
        }
    }
}
