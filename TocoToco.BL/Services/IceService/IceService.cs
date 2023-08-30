using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.IceDTOs;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.IceService
{
    public class IceService : BaseService<Ice, IceDTO, IceCreateDTO, IceUpdateDTO>, IIceService
    {
        public IceService(
            IIceRepository iceRepository,
            IMapper mapper
        ) : base(iceRepository, mapper)
        {
            
        }
    }
}
