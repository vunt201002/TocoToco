using TocoToco.Base;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.BL.Services.OrderService;

namespace TocoToco.Controllers
{
    public class OrderController : BaseController<OrderDTO, OrderCreateDTO, OrderUpdateDTO>
    {
        public OrderController(IOrderService orderService) : base(orderService)
        {
            
        }
    }
}
