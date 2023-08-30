using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.ToppingOrderDTOs;

namespace TocoToco.BL.Services.ToppingOrderService
{
    public interface IToppingOrderService : IBaseService<ToppingOrderDTO, ToppingOrderCreateDTO, ToppingOrderUpdateDTO>
    {
    }
}
