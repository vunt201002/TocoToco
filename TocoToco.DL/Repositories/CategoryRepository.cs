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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
            
        }
    }
}
