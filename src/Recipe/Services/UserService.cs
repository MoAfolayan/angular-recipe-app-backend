using Recipe.Data.Entities;
using Recipe.Data.UnitOfWork;

namespace Recipe.Services
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

        public void Add(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                user.CreatedDate = DateTime.UtcNow;
                user.IsActive = true;
            }

            _unitOfWork.Users.Insert(users);
        }

        public void Update(IEnumerable<User> users)
        {
            _unitOfWork.Users.Update(users);
        }

        public void Delete(IEnumerable<User> users)
        {
            _unitOfWork.Users.Delete(users);
        }
    }

    public interface IUserService : IService<User>
    {
        User GetUserByAuth0Id(string id);
    }
}
