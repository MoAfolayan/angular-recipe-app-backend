namespace Recipe.Services
{
    public interface IService<TEntity>
    {
        TEntity GetById(int id);
        void Add(IEnumerable<TEntity> entity);
        void Update(IEnumerable<TEntity> entity);
        void Delete(IEnumerable<TEntity> entity);
        // void DeleteMultiple(IEnumerable<TEntity> entities);
    }
}
