using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.SugarDTOs;

namespace TocoToco.BL.Services.SugarService
{
    public interface ISugarService : IBaseService<SugarDTO, SugarCreateDTO, SugarUpdateDTO>
    {
    }
}
