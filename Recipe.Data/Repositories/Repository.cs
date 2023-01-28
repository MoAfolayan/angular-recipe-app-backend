using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Recipe.Data.Repositories
{
    public abstract class Repository<TEntity> where TEntity : class
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
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                result = connection.Get<TEntity>(id);
            }

            return result;
        }

        public void Insert(TEntity entity)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Insert(entity);
            }
        }

        public void InsertMultiple(IEnumerable<TEntity> entities)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Insert(entities);
            }
        }

        public void Update(TEntity entity)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Update(entity);
            }
        }

        public void UpdateMultiple(IEnumerable<TEntity> entities)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Update(entities);
            }
        }

        public void Delete(TEntity entity)
        {
            var sql = $@"UPDATE {_tableName} 
                        SET IsActive = 0 
                        WHERE Id = @id";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Execute(sql, entity);
            }
        }

        public void DeleteMultiple(IEnumerable<TEntity> entities)
        {
            var sql = $@"UPDATE {_tableName} 
                        SET IsActive = 0 
                        WHERE Id = @id";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Execute(sql, entities);
            }
        }
    }

    public interface IRepository<TEntity> where TEntity : class
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
