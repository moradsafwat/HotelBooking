using HotelBooking.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext db;
        public Repository(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IList<TEntity> List()
        {
            return db.Set<TEntity>().ToList();
        }
        public TEntity Find(int id)
        {
            return db.Set<TEntity>().Find(id);
        }
        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            SaveAsync();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().AddRange(entities);
            SaveAsync();
        }

        public void Update(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            SaveAsync();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().UpdateRange(entities);
            SaveAsync();
        }

        public void Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            SaveAsync();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
            SaveAsync();
        }

        public void SaveAsync()
        {
            db.SaveChanges();
        }

        
    }
}
