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

        public override async Task<User> Get(Guid id)
        {
            var user = await _context.User
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }
    }
}
