using hr.Domain.Interfaces.Repositories;
using hr.Domain.Interfaces.Services;
using hr.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hr.Tests.Mocks
{
    public class ServicePeopleTest : IPeopleService
    {

        private readonly IRepositoryBase<People> _repositoryBase = new RepositoryPeopleTest();

        public Task<People> Add(People entity)
        {
            return _repositoryBase.Add(entity);
        }

        public void Dispose()
        {
        }

        public Task<People> Get(People entity)
        {
            return _repositoryBase.Get(entity);
        }

        public Task<IEnumerable<People>> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public Task<People> GetById(Guid id)
        {
            return _repositoryBase.GetById(id);
        }

        public Task Remove(People entity)
        {
            return _repositoryBase.Remove(entity);
        }

        public Task<int> SaveChanges()
        {
            return _repositoryBase.SaveChanges();
        }

        public Task Set(People entity)
        {
            return _repositoryBase.Set(entity);
        }
    }
}
