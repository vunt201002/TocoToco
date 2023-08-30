using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.ToppingDTOs;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.ToppingService
{
    public class ToppingService : BaseService<Topping, ToppingDTO, ToppingCreateDTO, ToppingUpdateDTO>, IToppingService
    {
        public ToppingService(
            IToppingRepository toppingRepository,
            IMapper mapper
        ) : base( toppingRepository, mapper )
        {
            
        }
    }
}
