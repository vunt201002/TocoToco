using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TocoToco.DL.Base;

namespace TocoToco.BL.Base
{
    public class BaseService<TEntity, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto>
        where TEntity : class
        where TEntityDto : class
        where TEntityCreateDto : class
        where TEntityUpdateDto : class
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;
        protected readonly IMapper _mapper;

        public BaseService(
            IBaseRepository<TEntity> baseRepository,
            IMapper mapper
        )
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }


        #region Methods
        /// <summary>
        /// hàm thêm một bản ghi
        /// </summary>
        /// <param name="entity">bản ghi mới</param>
        /// <returns>int</returns>
        /// created by: ntvu (20/08/2023)
        public virtual async Task<int> Add(TEntityCreateDto entityCreateDto)
        {
            // lấy ra khóa chính
            var primaryKeyProperty = entityCreateDto
                .GetType()
                .GetProperties()
                .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)));

            // set giá trị guid mới cho khóa chính
            if (primaryKeyProperty != null && primaryKeyProperty.PropertyType == typeof(Guid))
            {
                primaryKeyProperty.SetValue(entityCreateDto, Guid.NewGuid());
            }

            // map từ dto sang entity
            TEntity entity = _mapper.Map<TEntity>(entityCreateDto);

            // gửi xuống dl
            int res = await _baseRepository.Add(entity);

            if (res == 0)
            {
                throw new Exception("Thêm không thành công");
            }

            return res;
        }


        /// <summary>
        /// hàm xóa bản ghi
        /// </summary>
        /// <param name="id">id cần xóa</param>
        /// <returns>int</returns>
        /// created by: ntvu (20/08/2023)
        public virtual async Task<int> Delete(Guid id)
        {
            int res = await _baseRepository.Delete(id);

            if (res == 0)
            {
                throw new Exception("Xóa không thành công");
            }

            return res;
        }


        /// <summary>
        /// hàm lấy một bản ghi
        /// </summary>
        /// <param name="id">id cần lấy</param>
        /// <returns>TEntity</returns>
        /// created by: ntvu (20/08/2023)
        public virtual async Task<TEntityDto> Get(Guid id)
        {
            // lấy bản ghi
            TEntity entity = await _baseRepository.Get(id);

            if (entity == null)
            {
                throw new Exception("Không tìm thấy bản ghi");
            }

            // map sang dto
            TEntityDto entityDto = _mapper.Map<TEntityDto>(entity);

            return entityDto;
        }


        /// <summary>
        /// hàm lấy danh sách
        /// </summary>
        /// <returns>List<TEntityDto></returns>
        /// created by: ntvu (20/08/2023)
        public virtual async Task<List<TEntityDto>> GetList()
        {
            // lấy danh sách
            List<TEntity> entities = await _baseRepository.GetList();

            if (entities == null)
            {
                throw new Exception("Không tìm thấy danh sách");
            }

            // map sang dto
            List<TEntityDto> entitiesDto = _mapper.Map<List<TEntityDto>>(entities);

            return entitiesDto;
        }


        /// <summary>
        /// hàm sửa bản ghi
        /// </summary>
        /// <param name="entity">bản ghi mới</param>
        /// <returns>int</returns>
        /// created by: ntvu (20/08/2023)
        public virtual async Task<int> Update(TEntityUpdateDto entityUpdateDto)
        {
            // map từ dto sang entity
            TEntity entity = _mapper.Map<TEntity>(entityUpdateDto);

            // gửi xuống dl
            int res = await _baseRepository.Update(entity);

            return res;
        }
        #endregion
    }
}
