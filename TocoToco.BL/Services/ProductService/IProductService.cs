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
    }
}
