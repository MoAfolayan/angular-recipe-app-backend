using System;
using Recipe.Data.Entities;

namespace Recipe.Logic.Services.Interfaces
{
    public interface IService<TEntity>
    {
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
