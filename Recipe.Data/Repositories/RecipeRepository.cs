using System;
using rec = Recipe.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

using Recipe.Data.Repositories.Interfaces;

namespace Recipe.Data.Repositories
{
    public class RecipeRepository : Repository<rec.Recipe>, IRecipeRepository
    {
        public RecipeRepository(IConfiguration configuration) 
            : base(configuration)
        {
            _tableName = "Recipe";
        }
    }
}
