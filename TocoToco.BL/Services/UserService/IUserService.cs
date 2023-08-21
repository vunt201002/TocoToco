﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.UserDTOs;

namespace TocoToco.BL.Services.UserService
{
    public interface IUserService : IBaseService<UserDTO, UserCreateDTO, UserUpdateDTO>
    {
    }
}