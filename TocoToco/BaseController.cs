using Microsoft.AspNetCore.Mvc;
using TocoToco.BL.Base;

namespace TocoToco
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : ControllerBase
        where TEntity : class
        where TEntityDto : class
        where TEntityCreateDto : class
        where TEntityUpdateDto : class
    {
        protected readonly IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> _baseService;

        #region Constructor
        public BaseController(
            IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> baseService
        )
        {
            _baseService = baseService;
        }
        #endregion


        /// <summary>
        /// hàm lấy danh sách
        /// </summary>
        /// <returns></returns>
        /// created by: ntvu (20/08/2023)
        [HttpGet]
        public virtual async Task<IActionResult> GetList()
        {
            List<TEntityDto> entities = await _baseService.GetList();

            return Ok(entities);
        }

        /// <summary>
        /// hàm lấy 1 bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// created by: ntvu (20/08/2023)
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get([FromRoute] Guid id)
        {
            TEntityDto entity = await _baseService.Get(id);

            return Ok(entity);
        }

        /// <summary>
        /// hàm thêm mới bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// created by: ntvu (20/08/2023)
        [HttpPost]
        public virtual async Task<IActionResult> Add([FromBody] TEntityCreateDto entity)
        {
            int res = await _baseService.Add(entity);

            return Ok(res);
        }

        /// <summary>
        /// hàm sửa bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// created by: ntvu (20/08/2023)
        [HttpPut("id")]
        public virtual async Task<IActionResult> Update([FromBody] TEntityUpdateDto entity)
        {
            int res = await _baseService.Update(entity);

            return Ok(res);
        }

        /// <summary>
        /// hàm xóa bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// created by: ntvu (20/08/2023)
        [HttpDelete]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            int res = await _baseService.Delete(id);

            return Ok(res);
        }
    }
}
