using System;
using Recipe.Data.Entities;
using Recipe.Data.Repositories;

namespace Recipe.Data
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
