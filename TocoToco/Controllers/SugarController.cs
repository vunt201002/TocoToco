using TocoToco.Base;
using TocoToco.BL.DTOs.SugarDTOs;
using TocoToco.BL.Services.SugarService;

namespace TocoToco.Controllers
{
    public class SugarController : BaseController<SugarDTO, SugarCreateDTO, SugarUpdateDTO>
    {
        public SugarController(ISugarService sugarService) : base(sugarService)
        {
            
        }
    }
}
