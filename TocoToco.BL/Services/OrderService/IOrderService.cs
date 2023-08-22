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
    }
}
