using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocoToco.DL.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// hàm lấy danh sách
        /// </summary>
        /// <returns>IEnumerable<TEntity></returns>
        /// created by: ntvu (20/08/2023)
        public Task<List<TEntity>> GetList();

        /// <summary>
        /// hàm lấy một bản ghi
        /// </summary>
        /// <param name="id">id cần lấy</param>
        /// <returns>TEntity</returns>
        /// created by: ntvu (20/08/2023)
        public Task<TEntity> Get(Guid id);

        /// <summary>
        /// hàm thêm một bản ghi
        /// </summary>
        /// <param name="entity">bản ghi mới</param>
        /// <returns>int</returns>
        /// created by: ntvu (20/08/2023)
        public Task<int> Add(TEntity entity);

        /// <summary>
        /// hàm sửa bản ghi
        /// </summary>
        /// <param name="entity">bản ghi mới</param>
        /// <returns>int</returns>
        /// created by: ntvu (20/08/2023)
        public Task<int> Update(TEntity entity);

        /// <summary>
        /// hàm xóa bản ghi
        /// </summary>
        /// <param name="id">id cần xóa</param>
        /// <returns>int</returns>
        /// created by: ntvu (20/08/2023)
        public Task<int> Delete(Guid id);
    }
}
