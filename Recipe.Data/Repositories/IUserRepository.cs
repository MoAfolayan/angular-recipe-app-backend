using System;
using Recipe.Data.Entities;

namespace Recipe.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByAuth0Id(string auth0Id);
    }
}
