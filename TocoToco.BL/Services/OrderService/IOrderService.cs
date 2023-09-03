using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.OrderDTOs;

namespace TocoToco.BL.Services.OrderService
{
    public interface IOrderService : IBaseService<OrderDTO, OrderCreateDTO, OrderUpdateDTO>
    {
        /// <summary>
        /// hàm thêm và trả về id của
        /// order mới
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Task<Guid></returns>
        /// created by: ntvu (01/09/2023)
        public Task<Guid> AddReturnId(OrderCreateDTO order);
    }
}
