using Recipe.Data.Repositories;

namespace Recipe.Data
{
    public interface IUnitOfWork
    {
        IUserRepository  Users { get; }
    }
}