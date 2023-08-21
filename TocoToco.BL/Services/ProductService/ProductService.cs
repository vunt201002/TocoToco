using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.ProductDTOs;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.ProductService
{
    public class ProductService : BaseService<Product, ProductDTO, ProductCreateDTO, ProductUpdateDTO>, IProductService
    {
        public ProductService(
            IProductRepository productRepository,
            IMapper mapper
        ) : base(productRepository, mapper)
        {
            
        }
    }
}
