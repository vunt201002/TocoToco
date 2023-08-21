using TocoToco.Base;
using TocoToco.BL.DTOs.CategoryDTOs;
using TocoToco.BL.Services.CategoryService;

namespace TocoToco.Controllers
{
    public class CategoryController : BaseController<CategorryDTO, CategoryCreateDTO, CategoryUpdateDTO>
    {
        public CategoryController(ICategoryService categoryService) : base(categoryService)
        {
            
        }
    }
}
