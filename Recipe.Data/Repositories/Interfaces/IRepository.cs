using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void InsertMultiple(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateMultiple(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteMultiple(IEnumerable<TEntity> entities);
    }
}
