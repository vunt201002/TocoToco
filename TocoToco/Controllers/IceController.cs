using TocoToco.Base;
using TocoToco.BL.DTOs.IceDTOs;
using TocoToco.BL.Services.IceService;

namespace TocoToco.Controllers
{
    public class IceController : BaseController<IceDTO, IceCreateDTO, IceUpdateDTO>
    {
        public IceController(IIceService iceService) : base(iceService)
        {
            
        }
    }
}
