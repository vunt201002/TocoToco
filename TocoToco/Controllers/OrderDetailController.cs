using TocoToco.Base;
using TocoToco.BL.DTOs.OrderDetailDTOs;
using TocoToco.BL.Services.OrderDetailService;

namespace TocoToco.Controllers
{
    public class OrderDetailController : BaseController<OrderDetailDTO, OrderDetailCreateDTO, OrderDetailUpdateDTO>
    {
        public OrderDetailController(IOrderDetailService orderDetailService) : base(orderDetailService)
        {
            
        }
    }
}
