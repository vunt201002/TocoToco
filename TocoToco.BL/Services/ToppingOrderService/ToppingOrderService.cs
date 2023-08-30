using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.ToppingOrderDTOs;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.ToppingOrderService
{
    public class ToppingOrderService : BaseService<ToppingOrder, ToppingOrderDTO, ToppingOrderCreateDTO, ToppingOrderUpdateDTO>, IToppingOrderService
    {
        public ToppingOrderService(
            IToppingOrderRepository toppingOrderRepository,
            IMapper mapper
        ) : base(toppingOrderRepository, mapper)
        {
            
        }
    }
}
