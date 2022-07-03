using System;
using Recipe.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

using Recipe.Data.Repositories.Interfaces;

namespace Recipe.Data.Repositories
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(IConfiguration configuration)
            : base(configuration)
        {
            _tableName = "Ingredient";
        }
    }
}
