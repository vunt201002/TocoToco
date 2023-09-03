using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.ProductDTOs;

namespace TocoToco.BL.Services.ProductService
{
    public interface IProductService : IBaseService<ProductDTO, ProductCreateDTO, ProductUpdateDTO>
    {
        /// <summary>
        /// hàm search sản phẩm
        /// bằng tên
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>Task<IEnumerable<ProductDTO>></returns>
        /// created by: ntvu (31/08/2023)
        public Task<IEnumerable<ProductDTO>> Search(string searchText);
    }
}
