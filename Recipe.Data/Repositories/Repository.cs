using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Recipe.Data.Repositories
{
    public abstract class Repository<TEntity> where TEntity: class
    {
        protected readonly IConfiguration _configuration;

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TEntity GetById(int id)
        {
            TEntity result = null;
            var sql = "SELECT * FROM Users WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                result = connection.QuerySingleOrDefault<TEntity>(sql, new { Id = id } );
            }
            
            return result;
        }

        public void Add(TEntity entity)
        {
        }

        public void Update(TEntity entity)
        {
        }

        public void Delete(TEntity entity)
        {
        }
    }
}
