using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TocoToco.DL.Context;

namespace TocoToco.DL.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        #region Properties
        protected readonly DataContext _context;
        #endregion

        #region Constructors
        public BaseRepository(DataContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        /// <summary>
        /// hàm thêm một bản ghi
        /// </summary>
        /// <param name="entity">bản ghi mới</param>
        /// <returns>int</returns>
        /// created by: ntvu (20/08/2023)
        public virtual async Task<int> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            int res = await _context.SaveChangesAsync();

            return res > 0 ? 1 : 0;
        }

        /// <summary>
        /// hàm xóa bản ghi
        /// </summary>
        /// <param name="id">id cần xóa</param>
        /// <returns>int</returns>
        /// created by: ntvu (20/08/2023)
        public virtual async Task<int> Delete(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity != null)
            {
                _context.Entry(entity).Property("Deleted").CurrentValue = 1;
                _context.Entry(entity).Property("Deleted").IsModified = true;

            }

            int res = await _context.SaveChangesAsync();

            return res > 0 ? 1 : 0;
        }

        /// <summary>
        /// hàm lấy một bản ghi
        /// </summary>
        /// <param name="id">id cần lấy</param>
        /// <returns>TEntity</returns>
        /// created by: ntvu (20/08/2023)
        public virtual async Task<TEntity> Get(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            return entity;
        }

        /// <summary>
        /// hàm lấy danh sách
        /// </summary>
        /// <returns>IEnumerable<TEntity></returns>
        /// created by: ntvu (20/08/2023)
        public virtual async Task<List<TEntity>> GetList()
        {
            var entities = await _context.Set<TEntity>()
                .Where(e => EF.Property<int>(e, "Deleted") == 0)
                .ToListAsync();

            return entities;
        }

        /// <summary>
        /// hàm sửa bản ghi
        /// </summary>
        /// <param name="entity">bản ghi mới</param>
        /// <returns>int</returns>
        /// created by: ntvu (20/08/2023)
        public virtual async Task<int> Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            int res = await _context.SaveChangesAsync();

            return res > 0 ? 1 : 0;
        }
        #endregion
    }
}
