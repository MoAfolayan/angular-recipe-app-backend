using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            _tableName = "Recipes";
        }

        public IEnumerable<rec.Recipe> GetAllUserRecipesByUserId(int userId)
        {
            IEnumerable<rec.Recipe> result = null;
            var sql = @"SELECT r.*, i.Id as IngredientID, i.*
                        FROM Recipes r
                        LEFT JOIN Ingredients i
                            ON r.Id = i.RecipeId
                        WHERE r.UserId = @UserId
                            AND r.IsActive = 1
                            AND (i.IsActive IS NULL OR i.IsActive = 1)";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var recipeDictionary = new Dictionary<int, rec.Recipe>();

                result = connection.Query<rec.Recipe, rec.Ingredient, rec.Recipe>
                (
                    sql,
                    (recipe, ingredient) =>
                    {
                        rec.Recipe recipeEntry;

                        if (!recipeDictionary.TryGetValue(recipe.Id, out recipeEntry))
                        {
                            recipeEntry = recipe;
                            recipeEntry.Ingredients = new List<rec.Ingredient>();
                            recipeDictionary.Add(recipeEntry.Id, recipeEntry);
                        }

                        if (ingredient.Name != null)
                        {
                            recipeEntry.Ingredients.Add(ingredient);
                        }

                        return recipeEntry;
                    },
                    new { UserId = userId },
                    splitOn: "IngredientID"
                )
                .Distinct()
                .ToList();
            }

            return result;
        }
    }
}
