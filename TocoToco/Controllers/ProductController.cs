using Microsoft.AspNetCore.Mvc;
using TocoToco.Base;
using TocoToco.BL.DTOs.ProductDTOs;
using TocoToco.BL.Services.ProductService;

namespace TocoToco.Controllers
{
    public class ProductController : BaseController<ProductDTO, ProductCreateDTO, ProductUpdateDTO>
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) : base(productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// hàm search sản phẩm bằng
        /// tên
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>Task<IEnumerable<ProductDTO>></returns>
        /// created by: ntvu (31/08/2023)
        [HttpGet("search")]
        public async Task<IEnumerable<ProductDTO>> Search(string searchText)
        {
            IEnumerable<ProductDTO> productDTOs = await _productService.Search(searchText);

            return productDTOs;
        }
    }
}
