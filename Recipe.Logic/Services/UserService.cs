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

        public User GetUser(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }
    }
}
