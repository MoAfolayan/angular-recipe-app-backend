namespace Recipe.Services
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
