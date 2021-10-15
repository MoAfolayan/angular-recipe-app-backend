using System;
using Recipe.Data.Entities;

namespace Recipe.Logic.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserByAuth0Id(string id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
