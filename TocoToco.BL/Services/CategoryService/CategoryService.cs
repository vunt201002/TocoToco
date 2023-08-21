using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.CategoryDTOs;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.CategoryService
{
    public class CategoryService : BaseService<Category, CategorryDTO, CategoryCreateDTO, CategoryUpdateDTO>, ICategoryService
    {
        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper
        ) : base(categoryRepository, mapper)
        {
            
        }
    }
}
