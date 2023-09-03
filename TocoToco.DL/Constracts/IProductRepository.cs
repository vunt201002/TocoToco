using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.DL.Base;
using TocoToco.DL.Entities;

namespace TocoToco.DL.Constracts
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        /// <summary>
        /// tìm sản phẩm bằng tên
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>Task<Product></returns>
        /// created by: ntvu (31/08/2023)
        public Task<IEnumerable<Product>> Search(string searchText);
    }
}
