using TocoToco.Base;
using TocoToco.BL.DTOs.RoleDTOs;
using TocoToco.BL.Services.RoleService;
using TocoToco.DL.Entities;

namespace TocoToco.Controllers
{
    public class RoleController : BaseController<RoleDTO, RoleCreateDTO, RoleUpdateDTO>
    {
        public RoleController(IRoleService roleService) : base(roleService)
        {

        }
    }
}
