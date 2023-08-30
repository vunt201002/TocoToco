using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.SugarDTOs;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.SugarService
{
    public class SugarService : BaseService<Sugar, SugarDTO, SugarCreateDTO, SugarUpdateDTO>, ISugarService
    {
        public SugarService(
            ISugarRepository sugarRepository,
            IMapper mapper
        ) : base( sugarRepository, mapper )
        {
            
        }
    }
}
