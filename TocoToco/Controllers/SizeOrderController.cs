using TocoToco.Base;
using TocoToco.BL.DTOs.SizeOrderDTOs;
using TocoToco.BL.Services.SizeOrderService;

namespace TocoToco.Controllers
{
    public class SizeOrderController : BaseController<SizeOrderDTO, SizeOrderCreateDTO, SizeOrderUpdateDTO>
    {
        public SizeOrderController(ISizeOrderService sizeOrderService) : base(sizeOrderService)
        {
            
        }
    }
}
