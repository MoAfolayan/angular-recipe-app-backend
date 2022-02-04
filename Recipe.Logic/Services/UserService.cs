using System;
using System.Collections.Generic;
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

      public User GetById(int id)
      {
         return _unitOfWork.Users.GetById(id);
      }

      public User GetUserByAuth0Id(string auth0Id)
      {
         return _unitOfWork.Users.GetUserByAuth0Id(auth0Id);
      }

      public void Add(User user)
      {
         user.CreatedDate = DateTime.UtcNow;
         user.IsActive = true;
         _unitOfWork.Users.Insert(user);
      }

      public void Update(User user)
      {
         _unitOfWork.Users.Update(user);
      }

      public void Delete(User user)
      {
         _unitOfWork.Users.Delete(user);
      }

      public void DeleteMultiple(IEnumerable<User> users)
      {
         _unitOfWork.Users.DeleteMultiple(users);
      }
   }
}
