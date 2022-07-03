using System;
using Recipe.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

using Recipe.Data.Repositories.Interfaces;

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
}
