using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketSquare.API.Data.Repositories
{
    public class NoticesRepository : Repository<Notice>, INoticesRepository
    {
        protected DbContext DbContext;
        protected DbSet<Notice> DbSet;
        public NoticesRepository(DbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = DbContext.Set<Notice>();
        }

        public IEnumerable<Notice> GetAllNotices()
        {
            return DbSet.Include(x => x.NoticeTags).ThenInclude(x=>x.Tag);
        }
          public IEnumerable<Notice> GetAllNotices(int [] tags)
        {            
            return DbSet
                .Where(n => n.NoticeTags.Any(nt => tags.Contains(nt.Tag.Id)))
                .Include(x => x.NoticeTags)
                .ThenInclude(x=>x.Tag);
        }
    }
}