using Recipe.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace Recipe.Data.Repositories
{
    public class CheckListItemRepository : Repository<CheckListItem>, ICheckListItemRepository
    {
        public CheckListItemRepository(IConfiguration configuration)
            : base(configuration)
        {
            _tableName = "CheckListItem";
        }
    }

    public interface ICheckListItemRepository : IRepository<CheckListItem>
    {
    }
}
