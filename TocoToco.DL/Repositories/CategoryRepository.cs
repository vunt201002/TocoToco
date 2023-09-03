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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// override hàm get list
        /// </summary>
        /// <returns>Task<List<Category>></returns>
        /// created by: ntvu (31/08/2023)
        public override async Task<List<Category>> GetList()
        {
            List<Category> categories = await _context.Category
                .Include(x => x.Products)
                .Where(e => EF.Property<int>(e, "Deleted") == 0)
                .ToListAsync();

            return categories;
        }
    }
}
