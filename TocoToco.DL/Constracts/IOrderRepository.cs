using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.DL.Base;
using TocoToco.DL.Entities;

namespace TocoToco.DL.Constracts
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        /// <summary>
        /// hàm thêm và trả về id của
        /// order mới
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Task<Guid></returns>
        /// created by: ntvu (01/09/2023)
        public Task<Guid> AddReturnId(Order order);
    }
}
