using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.OrderService
{
    public class OrderService : BaseService<Order, OrderDTO, OrderCreateDTO, OrderUpdateDTO>, IOrderService
    {
        public OrderService(
            IOrderRepository orderRepository,
            IMapper mapper
        ) : base(orderRepository, mapper)
        {
            
        }
    }
}
