using MarketSquare.API.Data.Models;

namespace MarketSquare.API.Data.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> Create<TEntity>() where TEntity : IEntity;
    }
}