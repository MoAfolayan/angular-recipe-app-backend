using Recipe.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Recipe.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration)
            : base(configuration)
        {
            _tableName = "User";
        }

        public User GetUserByAuth0Id(string auth0Id)
        {
            User result = null;
            var sql =
                @"SELECT * 
                        FROM [dbo].[User] 
                        WHERE Auth0Id = @Auth0Id
                            AND IsActive = 1";

            using (
                var connection = new SqlConnection(
                    _configuration.GetConnectionString("DefaultConnection")
                )
            )
            {
                result = connection.QuerySingleOrDefault<User>(sql, new { Auth0Id = auth0Id });
            }

            return result;
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        User GetUserByAuth0Id(string auth0Id);
    }
}
