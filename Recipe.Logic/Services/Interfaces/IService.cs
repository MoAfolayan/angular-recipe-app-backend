using System;
using Recipe.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.Logic.Services.Interfaces
{
   public interface IService<TEntity>
   {
      TEntity GetById(int id);
      void Add(TEntity entity);
      void Update(TEntity entity);
      void Delete(TEntity entity);
      void DeleteMultiple(IEnumerable<TEntity> entities);
   }
}
