using System;
using Recipe.Data.Repositories;
using Recipe.Data;
using Recipe.Data.Entities;
using Recipe.Logic.Services.Interfaces;
using Recipe.Data.UnitOfWork.Interfaces;

namespace Recipe.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUserByAuth0Id(string auth0Id)
        {
            return _unitOfWork.Users.GetUserByAuth0Id(auth0Id);
        }

        public void AddUser(User user)
        {
            user.CreatedDate = DateTime.UtcNow;
            user.IsActive = true;
            _unitOfWork.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            _unitOfWork.Users.Update(user);
        }

        public void DeleteUser(User user)
        {
            _unitOfWork.Users.Delete(user);
        }
    }
}
