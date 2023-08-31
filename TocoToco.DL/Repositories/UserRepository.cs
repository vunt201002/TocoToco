using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TocoToco.DL.Base;
using TocoToco.DL.Constracts;
using TocoToco.DL.Context;
using TocoToco.DL.Entities;

namespace TocoToco.DL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// hàm ghi đè hàm add từ
        /// base.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// created by: ntvu (21/08/2023)
        public override async Task<int> Add(User entity)
        {
            if (entity.Role != null)
            {
                _context.Entry(entity.Role).State = EntityState.Unchanged;
            }
            _context.Add(entity);
            int res =  await _context.SaveChangesAsync();

            return res > 0 ? 1 : 0;
        }

        /// <summary>
        /// hàm overrid hàm get,
        /// trả về cả role
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task<User></returns>
        /// created by: ntvu (21/08/2023)
        public override async Task<User> Get(Guid id)
        {
            var user = await _context.User
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        /// <summary>
        /// hàm kiểm tra email tồn tại
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Task<User></returns>
        /// created by: ntvu (31/08/2023)
        public async Task<User> CheckEmailExist(string email)
        {
            User? user = await _context
                .User
                .FirstOrDefaultAsync(user => user.Email == email);

            return user;
        }

        /// <summary>
        /// hàm lưu rf token vào db
        /// sau khi login.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<int> UpdateRfToken(Guid Id, string token)
        {
            User? user = await _context.User.FirstOrDefaultAsync(x => x.Id == Id);

            user.RefreshToken = token;
            user.RfExpireTime = DateTime.Now.AddDays(100);

            int res = await _context.SaveChangesAsync();

            return res > 0 ? 1 : 0;
        }
    }
}
