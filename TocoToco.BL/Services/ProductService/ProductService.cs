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
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductService(
            IProductRepository productRepository,
            IMapper mapper
        ) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// hàm search sản phẩm
        /// bằng tên
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>Task<IEnumerable<ProductDTO>></returns>
        /// created by: ntvu (31/08/2023)
        public async Task<IEnumerable<ProductDTO>> Search(string searchText)
        {
            IEnumerable<Product> products = await _productRepository.Search(searchText);

            IEnumerable<ProductDTO> productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return productDTOs;
        }
    }
}
