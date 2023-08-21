using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.CategoryDTOs;

namespace TocoToco.BL.Services.CategoryService
{
    public interface ICategoryService : IBaseService<CategorryDTO, CategoryCreateDTO, CategoryUpdateDTO>
    {
    }
}
