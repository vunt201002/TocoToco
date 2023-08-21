using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.RoleDTOs;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.RoleService
{
    public class RoleService : BaseService<Role, RoleDTO, RoleCreateDTO, RoleUpdateDTO>, IRoleService
    {
        public RoleService(
            IRoleRepository roleRepository,
            IMapper mapper
        ) : base(roleRepository, mapper)
        {
        }
    }
}
