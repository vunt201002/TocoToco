using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.OrderDetailDTOs;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.OrderDetailService
{
    public class OrderDetailService : BaseService<OrderDetail, OrderDetailDTO, OrderDetailCreateDTO, OrderDetailService>, IOrderDetailService
    {
        public OrderDetailService(
            IOrderDetailRepository orderDetailRepository,
            IMapper mapper
        ) : base( orderDetailRepository, mapper )
        {
            
        }

        public Task<int> Update(OrderDetailUpdateDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
