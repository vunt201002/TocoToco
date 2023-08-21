using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.UserDTOs;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.UserService
{
    public class UserService : BaseService<User, UserDTO, UserCreateDTO, UserUpdateDTO>, IUserService
    {
        public UserService(
            IUserRepository userRepository,
            IMapper mapper
        ) : base(userRepository, mapper)
        {
        }
    }
}
