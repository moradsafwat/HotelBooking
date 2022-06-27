using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int id);
        void AddRange(IEnumerable<TEntity> entities);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void SaveAsync();
    }
}
