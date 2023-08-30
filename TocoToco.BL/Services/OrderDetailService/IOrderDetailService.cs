using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.OrderDetailDTOs;

namespace TocoToco.BL.Services.OrderDetailService
{
    public interface IOrderDetailService : IBaseService<OrderDetailDTO, OrderDetailCreateDTO, OrderDetailUpdateDTO>
    {
    }
}
