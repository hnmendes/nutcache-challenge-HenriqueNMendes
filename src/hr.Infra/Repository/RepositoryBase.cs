using System;
using hr.Infra.Context;
using System.Threading.Tasks;
using hr.Domain.Models.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using hr.Domain.Interfaces.Repositories;


namespace hr.Infra.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : Entity, new()
    {
        protected readonly HrDbContext Db;
        protected readonly DbSet<TEntity> ?DbSet;

        protected RepositoryBase(HrDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {
            Db.Add(entity);
            await SaveChanges();
        }        

        public virtual async Task<TEntity> Get(TEntity entity)
        {
            return await DbSet.FindAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Remove(TEntity entity)
        {
            Db.Remove(entity);
            await SaveChanges();
        }        

        public virtual async Task Set(TEntity entity)
        {
            Db.Update(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
