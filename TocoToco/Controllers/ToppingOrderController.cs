using TocoToco.Base;
using TocoToco.BL.DTOs.ToppingOrderDTOs;
using TocoToco.BL.Services.ToppingOrderService;

namespace TocoToco.Controllers
{
    public class ToppingOrderController : BaseController<ToppingOrderDTO, ToppingOrderCreateDTO, ToppingOrderUpdateDTO>
    {
        public ToppingOrderController(IToppingOrderService toppingOrderService) : base(toppingOrderService)
        {
            
        }
    }
}
