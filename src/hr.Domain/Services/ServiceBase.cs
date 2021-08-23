using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using hr.Domain.Interfaces.Services;
using hr.Domain.Interfaces.Repositories;

namespace hr.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {

        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public Task<TEntity> Add(TEntity entity)
        {
            return _repositoryBase.Add(entity);
        }

        public Task<TEntity> Get(TEntity entity)
        {
            return _repositoryBase.Get(entity);
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public Task<TEntity> GetById(Guid id)
        {
            return _repositoryBase.GetById(id);
        }

        public Task Remove(TEntity entity)
        {
            return _repositoryBase.Remove(entity);
        }

        public Task<int> SaveChanges()
        {
            return _repositoryBase.SaveChanges();
        }

        public Task Set(TEntity entity)
        {
            return _repositoryBase.Set(entity);
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }
    }
}
