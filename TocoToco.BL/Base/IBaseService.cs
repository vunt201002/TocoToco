using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocoToco.BL.Base
{
    public interface IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto>
        where TEntityDto : class
        where TEntityCreateDto : class
        where TEntityUpdateDto : class
    {
        /// <summary>
        /// hàm lấy danh sách
        /// </summary>
        /// <returns>List<TEntity></returns>
        /// created by: ntvu (20/08/2023)
        public Task<List<TEntityDto>> GetList();

        /// <summary>
        /// hàm lấy một bản ghi
        /// </summary>
        /// <param name="id">id cần lấy</param>
        /// <returns>TEntity</returns>
        /// created by: ntvu (20/08/2023)
        public Task<TEntityDto> Get(Guid id);

        /// <summary>
        /// hàm thêm một bản ghi
        /// </summary>
        /// <param name="entity">bản ghi mới</param>
        /// <returns>int</returns>
        /// created by: ntvu (20/08/2023)
        public Task<int> Add(TEntityCreateDto entity);

        /// <summary>
        /// hàm sửa bản ghi
        /// </summary>
        /// <param name="entity">bản ghi mới</param>
        /// <returns>int</returns>
        /// created by: ntvu (20/08/2023)
        public Task<int> Update(TEntityUpdateDto entity);

        /// <summary>
        /// hàm xóa bản ghi
        /// </summary>
        /// <param name="id">id cần xóa</param>
        /// <returns>int</returns>
        /// created by: ntvu (20/08/2023)
        public Task<int> Delete(Guid id);
    }
}
