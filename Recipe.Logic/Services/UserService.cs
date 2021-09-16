using System;
using Recipe.Data.Repositories;
using Recipe.Data;
using Recipe.Data.Entities;

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
    }
}
