using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rec = Recipe.Data.Entities;

namespace Recipe.Logic.Services.Interfaces
{
    public interface IRecipeService : IService<rec.Recipe>
    {
        IEnumerable<rec.Recipe> GetAllUserRecipesByUserId(int userId);
    }
}
