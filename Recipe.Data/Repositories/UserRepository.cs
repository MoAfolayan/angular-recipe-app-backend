using System;
using Recipe.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Recipe.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public User GetUserByAuth0Id(string auth0Id)
        {
            User result = null;
            var sql = "SELECT * FROM Users WHERE Auth0Id = @Auth0Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                result = connection.QuerySingleOrDefault<User>(sql, new { Auth0Id = auth0Id } );
            }
            
            return result;
        }
    }
}
