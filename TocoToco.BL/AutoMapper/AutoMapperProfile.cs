using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.DTOs.CategoryDTOs;
using TocoToco.BL.DTOs.IceDTOs;
using TocoToco.BL.DTOs.OrderDetailDTOs;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.BL.DTOs.ProductDTOs;
using TocoToco.BL.DTOs.RoleDTOs;
using TocoToco.BL.DTOs.SizeOrderDTOs;
using TocoToco.BL.DTOs.SugarDTOs;
using TocoToco.BL.DTOs.ToppingDTOs;
using TocoToco.BL.DTOs.ToppingOrderDTOs;
using TocoToco.BL.DTOs.TypeOrderDTOs;
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
                    src => new Role { Id = src.RoleId }))
                .ForMember(dest => dest.PasswordHash, option => option.MapFrom(
                    src => src.Password));
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

            // type order
            CreateMap<TypeOrder, TypeOrderDTO>();
            CreateMap<TypeOrderCreateDTO, TypeOrder>();
            CreateMap<TypeOrderUpdateDTO, TypeOrder>();

            // size order
            CreateMap<SizeOrder, SizeOrderDTO>();
            CreateMap<SizeOrderCreateDTO, SizeOrder>();
            CreateMap<SizeOrderUpdateDTO, SizeOrder>();

            // sugar
            CreateMap<Sugar, SugarDTO>();
            CreateMap<SugarCreateDTO, Sugar>();
            CreateMap<SugarUpdateDTO, Sugar>();

            // ice
            CreateMap<Ice, IceDTO>();
            CreateMap<IceCreateDTO, Ice>();
            CreateMap<IceUpdateDTO, Ice>();

            // topping
            CreateMap<Topping, ToppingDTO>();
            CreateMap<ToppingCreateDTO, Topping>();
            CreateMap<ToppingUpdateDTO, Topping>();

            // order detail
            CreateMap<OrderDetail, OrderDetailDTO>();
            CreateMap<OrderDetailCreateDTO, OrderDetail>();
            CreateMap<OrderDetailUpdateDTO, OrderDetail>();

            // topping order
            CreateMap<ToppingOrder, ToppingOrderDTO>();
            CreateMap<ToppingOrderCreateDTO, ToppingOrder>();
            CreateMap<ToppingOrderUpdateDTO, ToppingOrder>();

        }
    }
}
