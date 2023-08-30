using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.SizeOrderDTOs;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.SizeOrderService
{
    public class SizeOrderService : BaseService<SizeOrder, SizeOrderDTO, SizeOrderCreateDTO, SizeOrderUpdateDTO>, ISizeOrderService
    {
        public SizeOrderService(
            ISizeOrderRepository sizeOrderRepository,
            IMapper mapper
        ) : base( sizeOrderRepository, mapper )
        {
            
        }
    }
}
