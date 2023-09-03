using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.DL.Base;
using TocoToco.DL.Constracts;
using TocoToco.DL.Context;
using TocoToco.DL.Entities;

namespace TocoToco.DL.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// hàm thêm và trả về id của
        /// order mới
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Task<Guid></returns>
        /// created by: ntvu (01/09/2023)
        public async Task<Guid> AddReturnId(Order order)
        {
            await _context.AddAsync(order);
            int res = await _context.SaveChangesAsync();

            return res > 0 ? order.Id : Guid.Empty;
        }
    }
}
