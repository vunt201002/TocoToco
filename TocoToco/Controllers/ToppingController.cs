using TocoToco.Base;
using TocoToco.BL.DTOs.ToppingDTOs;
using TocoToco.BL.Services.ToppingService;

namespace TocoToco.Controllers
{
    public class ToppingController : BaseController<ToppingDTO, ToppingCreateDTO, ToppingUpdateDTO>
    {
        public ToppingController(IToppingService toppingService) : base(toppingService)
        {
            
        }
    }
}
