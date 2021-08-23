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

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            Db.Add(entity);
            await SaveChanges();

            return entity; 
        }        

        public virtual async Task<TEntity> Get(TEntity entity)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return await DbSet.FindAsync(entity);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return await DbSet.FindAsync(id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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
