using System;
using rec = Recipe.Data.Entities;

namespace Recipe.Data.Repositories.Interfaces
{
    public interface IRecipeRepository : IRepository<rec.Recipe>
    {
    }
}
