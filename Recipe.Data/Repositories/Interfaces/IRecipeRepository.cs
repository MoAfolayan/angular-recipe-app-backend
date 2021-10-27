using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rec = Recipe.Data.Entities;

namespace Recipe.Data.Repositories.Interfaces
{
    public interface IRecipeRepository : IRepository<rec.Recipe>
    {
        IEnumerable<rec.Recipe> GetAllUserRecipesByUserId(int userId);
    }
}
