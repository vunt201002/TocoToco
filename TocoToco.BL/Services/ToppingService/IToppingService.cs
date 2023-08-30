using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.ToppingDTOs;

namespace TocoToco.BL.Services.ToppingService
{
    public interface IToppingService : IBaseService<ToppingDTO, ToppingCreateDTO, ToppingUpdateDTO>
    {
    }
}
