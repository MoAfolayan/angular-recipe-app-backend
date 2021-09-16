using System;
using Recipe.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Recipe.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User GetById(int id)
        {
            User result = null;
            var sql = "SELECT * FROM Users WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                result = connection.QuerySingleOrDefault<User>(sql, new { Id = id} );
            }
            
            return result;
        }

        public User Insert(User entity)
        {
            return new User();
        }

        public User Update(User entity)
        {
            return new User();
        }

        public bool Delete(User entity)
        {
            return true;
        }
    }
}
