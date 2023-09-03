using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TocoToco.DL.Base;
using TocoToco.DL.Constracts;
using TocoToco.DL.Context;
using TocoToco.DL.Entities;

namespace TocoToco.DL.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// tìm sản phẩm bằng tên
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>Task<Product></returns>
        /// created by: ntvu (31/08/2023)
        public async Task<IEnumerable<Product>> Search(string searchText)
        {
            List<Product> products = await _context.Product
                .Where(p => p.Name.ToLower().Contains(searchText.ToLower()))
                .ToListAsync();

            return products;
        }
    }
}
