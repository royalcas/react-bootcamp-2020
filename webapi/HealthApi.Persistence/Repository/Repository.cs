using HealthApp.Domain;
using HealthApp.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HealthApi.Persistence.Repository
{
	public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
	{
        protected readonly HealthAppContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(HealthAppContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id.ToString().ToUpper());
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
