using System.Threading.Tasks;

namespace MarketSquare.API.Data
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}