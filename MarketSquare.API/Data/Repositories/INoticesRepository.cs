using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;

namespace MarketSquare.API.Data.Repositories
{
    public interface INoticesRepository : IRepository<Notice>
    {
        IEnumerable<Notice> GetAllNotices();
        IEnumerable<Notice> GetAllNotices(int[] tags);
    }
}