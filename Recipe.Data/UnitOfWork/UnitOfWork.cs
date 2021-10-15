using System;
using Recipe.Data.Entities;
using Recipe.Data.Repositories;
using Recipe.Data.Repositories.Interfaces;
using Recipe.Data.UnitOfWork.Interfaces;

namespace Recipe.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository)
        {
            Users = userRepository;
        }
        
        public IUserRepository Users { get; } 
    }
}
