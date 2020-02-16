using System;
using MarketSquare.API.Data.Models;

namespace MarketSquare.API.Data.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public IRepository<TEntity> Create<TEntity>() where TEntity : IEntity
        {
            return _serviceProvider.GetService(typeof(IRepository<TEntity>)) as IRepository<TEntity>;
        }
    }
}