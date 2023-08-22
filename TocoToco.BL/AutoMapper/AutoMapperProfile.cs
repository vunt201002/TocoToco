using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.DTOs.CategoryDTOs;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.BL.DTOs.ProductDTOs;
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
            CreateMap<User, UserDTO>();
            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.Role, option => option.MapFrom(
                    src => new Role { Id = src.RoleId}));
            CreateMap<UserUpdateDTO, User>();

            // category
            CreateMap<Category, CategorryDTO>();
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();

            // product
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductCreateDTO, Product>();
            CreateMap<ProductUpdateDTO, Product>();

            // order
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderCreateDTO, Order>();
            CreateMap<OrderUpdateDTO, Order>();

        }
    }
}
