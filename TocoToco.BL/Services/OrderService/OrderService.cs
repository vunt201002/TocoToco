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
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(
            IOrderRepository orderRepository,
            IMapper mapper
        ) : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// hàm tạo order mới
        /// và trả về id
        /// </summary>
        /// <param name="orderCreateDTO"></param>
        /// <returns>Task<Guid></returns>
        /// <exception cref="Exception"></exception>
        /// created by: ntvu (01/09/2023)
        public async Task<Guid> AddReturnId(OrderCreateDTO orderCreateDTO)
        {
            Order order = _mapper.Map<Order>( orderCreateDTO);

            order.Id = Guid.NewGuid();

            Guid newId = await _orderRepository.AddReturnId(order);

            if ( newId == Guid.Empty )
            {
                throw new Exception("Tạo order mới không thành công");
            }

            return newId;
        }
    }
}
