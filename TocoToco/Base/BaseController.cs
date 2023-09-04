using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TocoToco.BL.Base;
using TocoToco.Common.Models;
using static TocoToco.Common.Enumeration.Enum;

namespace TocoToco.Base
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntityDto, TEntityCreateDto, TEntityUpdateDto> : ControllerBase
        where TEntityDto : class
        where TEntityCreateDto : class
        where TEntityUpdateDto : class
    {
        #region Properties
        protected readonly IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> _baseService;
        #endregion

        #region Constructor
        public BaseController(
            IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> baseService
        )
        {
            _baseService = baseService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// hàm lấy danh sách
        /// </summary>
        /// <returns></returns>
        /// created by: ntvu (21/08/2023)
        [HttpGet]
        public virtual async Task<IActionResult> GetList()
        {
            List<TEntityDto> entities = await _baseService.GetList();

            if (entities  == null)
            {
                return HandleResult("Lỗi khi lấy danh sách", ReturnCode.BadRequest, entities);

            } else if (entities.Count == 0)
            {
                return HandleResult("Danh sách rỗng", ReturnCode.NoContent, entities);
            }

            return HandleResult("Lấy danh sách thành công", ReturnCode.Success, entities);
        }

        /// <summary>
        /// hàm lấy 1 bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// created by: ntvu (21/08/2023)
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get([FromRoute] Guid id)
        {
            TEntityDto entity = await _baseService.Get(id);

            if (entity == null)
            {
                return HandleResult("Lỗi khi lấy bản ghi", ReturnCode.BadRequest, entity);
            }

            return HandleResult("Lấy bản ghi thành công", ReturnCode.Success, entity);
        }

        /// <summary>
        /// hàm thêm mới bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// created by: ntvu (21/08/2023)
        [HttpPost]
        public virtual async Task<IActionResult> Add([FromBody] TEntityCreateDto entity)
        {
            int res = await _baseService.Add(entity);

            if (res == 0)
            {
                return HandleResult("Lỗi khi thêm", ReturnCode.BadRequest, res);
            }

            return HandleResult("Thêm thành công", ReturnCode.Success, res);
        }

        /// <summary>
        /// hàm sửa bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// created by: ntvu (21/08/2023)
        [HttpPut("id")]
        public virtual async Task<IActionResult> Update([FromBody] TEntityUpdateDto entity)
        {
            int res = await _baseService.Update(entity);

            if (res == 0)
            {
                return HandleResult("Lỗi khi sửa", ReturnCode.BadRequest, res);
            }

            return HandleResult("Sửa thành công", ReturnCode.Success, res);
        }

        /// <summary>
        /// hàm xóa bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// created by: ntvu (21/08/2023)
        [HttpDelete]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            int res = await _baseService.Delete(id);

            if (res == 0)
            {
                return HandleResult("Lỗi khi xóa", ReturnCode.BadRequest, res);
            }

            return HandleResult("Xóa thành công", ReturnCode.Success, res);
        } 

        protected IActionResult HandleResult(
            string message,
            ReturnCode returnCode,
            object? data = null
        )
        {
            ResponseModel responseModel = new ResponseModel();

            responseModel.DevMsg = message;
            responseModel.UserMsg = message;
            responseModel.Data = data;

            return StatusCode((int)returnCode, responseModel);
        }
        #endregion
    }
}
