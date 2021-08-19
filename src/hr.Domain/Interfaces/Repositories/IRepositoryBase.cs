using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hr.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity>: IDisposable where TEntity : class
    {
        Task Add(TEntity entity);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Get(TEntity entity);

        Task<TEntity> GetById(Guid id);

        Task Set(TEntity entity);

        Task Remove(TEntity entity);

        Task<int> SaveChanges();
    }
}
