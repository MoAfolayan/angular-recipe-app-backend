using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using Recipe.Data.Entities;

namespace Recipe.Data.Repositories
{
    public abstract class Repository<TEntity>
        where TEntity : Entity
    {
        protected readonly IConfiguration _configuration;
        protected string _tableName;

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TEntity GetById(int id)
        {
            TEntity result = null;
            using (
                var connection = new SqlConnection(
                    _configuration.GetConnectionString("DefaultConnection")
                )
            )
            {
                result = connection.Get<TEntity>(id);
            }

            return result;
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            using (
                var connection = new SqlConnection(
                    _configuration.GetConnectionString("DefaultConnection")
                )
            )
            {
                connection.Insert(entities);
            }
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            using (
                var connection = new SqlConnection(
                    _configuration.GetConnectionString("DefaultConnection")
                )
            )
            {
                connection.Update(entities);
            }
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            var sql =
                $@"UPDATE {_tableName} 
                        SET IsActive = 0 
                        WHERE Id in (@idList)";

            using (
                var connection = new SqlConnection(
                    _configuration.GetConnectionString("DefaultConnection")
                )
            )
            {
                connection.Execute(sql, new { idList = entities.Select(e => e.Id).ToList() });
            }
        }
    }

    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity GetById(int id);
        void Insert(IEnumerable<TEntity> entities);

        void Update(IEnumerable<TEntity> entities);

        void Delete(IEnumerable<TEntity> entities);
    }
}
