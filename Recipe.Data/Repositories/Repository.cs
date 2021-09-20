using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Recipe.Data.Repositories
{
    public abstract class Repository<TEntity> where TEntity: class
    {
        protected readonly IConfiguration _configuration;
        protected string _tableName;

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TEntity Get(int id)
        {
            TEntity result = null;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                result = connection.Get<TEntity>(id);
            }
            
            return result;
        }

        public void Add(TEntity entity)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Insert(entity);
            }
        }

        public void Update(TEntity entity)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Update(entity);
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
    }
}
