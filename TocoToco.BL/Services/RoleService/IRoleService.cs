using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.RoleDTOs;

namespace TocoToco.BL.Services.RoleService
{
    public interface IRoleService : IBaseService<RoleDTO, RoleCreateDTO, RoleUpdateDTO>
    {
    }
}
