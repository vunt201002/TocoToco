using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.TypeOrderDTOs;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.TypeOrderService
{
    public class TypeOrderService : BaseService<TypeOrder, TypeOrderDTO, TypeOrderCreateDTO, TypeOrderUpdateDTO>, ITypeOrderService
    {
        public TypeOrderService(
            ITypeOrderRepository typeOrderRepository,
            IMapper mapper
        ) : base( typeOrderRepository, mapper )
        {
            
        }
    }
}
