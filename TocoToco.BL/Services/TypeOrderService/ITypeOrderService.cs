using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.TypeOrderDTOs;

namespace TocoToco.BL.Services.TypeOrderService
{
    public interface ITypeOrderService : IBaseService<TypeOrderDTO, TypeOrderCreateDTO, TypeOrderUpdateDTO>
    {
    }
}
