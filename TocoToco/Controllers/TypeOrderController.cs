using TocoToco.Base;
using TocoToco.BL.DTOs.TypeOrderDTOs;
using TocoToco.BL.Services.TypeOrderService;

namespace TocoToco.Controllers
{
    public class TypeOrderController : BaseController<TypeOrderDTO, TypeOrderCreateDTO, TypeOrderUpdateDTO>
    {
        public TypeOrderController(ITypeOrderService typeOrderService) : base(typeOrderService)
        {
            
        }
    }
}
