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
        protected DbSet<Notice> DbSetNotices;
        protected DbSet<UserNotice> DbSetUserNotices;
        public NoticesRepository(DbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSetNotices = DbContext.Set<Notice>();
            DbSetUserNotices = DbContext.Set<UserNotice>();
        }

        public IEnumerable<Notice> GetAllNotices()
        {
            return DbSetNotices.Include(x => x.NoticeTags).ThenInclude(x=>x.Tag);
        }
        public IEnumerable<Notice> GetAllNotices(int [] tags)
        {            
            return DbSetNotices
                .Where(n => n.NoticeTags.Any(nt => tags.Contains(nt.Tag.Id)))
                .Include(x => x.NoticeTags)
                .ThenInclude(x=>x.Tag);
        }

        public IEnumerable<UserNotice> GetMyNotices(string username)
        {            
            return DbSetUserNotices                
                .Where(un => un.User.Username == username)
                .Include(x => x.Notice)
                .ThenInclude(n => n.NoticeTags)
                .ThenInclude(nt => nt.Tag)
                .Include(x => x.User);                
        }
    }
}