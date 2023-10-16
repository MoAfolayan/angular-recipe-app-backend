using Recipe.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace Recipe.Data.Repositories
{
    public class CheckListRepository : Repository<CheckList>, ICheckListRepository
    {
        public CheckListRepository(IConfiguration configuration)
            : base(configuration)
        {
            _tableName = "CheckList";
        }
    }

    public interface ICheckListRepository : IRepository<CheckList> { }
}
