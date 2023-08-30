using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.IceDTOs;

namespace TocoToco.BL.Services.IceService
{
    public interface IIceService : IBaseService<IceDTO, IceCreateDTO, IceUpdateDTO>
    {
    }
}
