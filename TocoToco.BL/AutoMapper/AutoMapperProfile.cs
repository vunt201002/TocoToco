using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.DTOs.RoleDTOs;
using TocoToco.BL.DTOs.UserDTOs;
using TocoToco.DL.Entities;

namespace TocoToco.BL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // role
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleCreateDTO, Role>();
            CreateMap<RoleUpdateDTO, Role>();

            // user
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.RoleDTO, option => option.MapFrom(src => src.Role));
            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.Role, option => option.MapFrom(
                    src => new Role { Id = src.RoleId}));
            CreateMap<UserUpdateDTO, User>();

        }
    }
}
