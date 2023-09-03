using Microsoft.AspNetCore.Mvc;
using TocoToco.Base;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.BL.Services.OrderService;

namespace TocoToco.Controllers
{
    public class OrderController : BaseController<OrderDTO, OrderCreateDTO, OrderUpdateDTO>
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) : base(orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// hàm tạo order mới và trả về id
        /// </summary>
        /// <param name="orderCreateDTO"></param>
        /// <returns>Task<Guid></returns>
        /// created by: ntvu (01/09/2023)
        [HttpPost("rid")]
        public async Task<Guid> AddReturnId(OrderCreateDTO orderCreateDTO)
        {
            Guid newId = await _orderService.AddReturnId(orderCreateDTO);

            return newId;
        }
    }
}
