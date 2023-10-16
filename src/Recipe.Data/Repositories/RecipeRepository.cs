using Rec = Recipe.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Recipe.Data.Repositories
{
    public class RecipeRepository : Repository<Rec.Recipe>, IRecipeRepository
    {
        public RecipeRepository(IConfiguration configuration)
            : base(configuration)
        {
            _tableName = "Recipe";
        }

        public IEnumerable<Rec.Recipe> GetAllUserRecipesByUserId(int userId)
        {
            IEnumerable<Rec.Recipe> result = null;
            var sql =
                @"SELECT r.*, i.Id as IngredientID, i.*
                        FROM Recipe r
                        LEFT JOIN Ingredient i
                            ON r.Id = i.RecipeId
                        WHERE r.UserId = @UserId
                            AND r.IsActive = 1
                            AND (i.IsActive IS NULL OR i.IsActive = 1)";

            using (
                var connection = new SqlConnection(
                    _configuration.GetConnectionString("DefaultConnection")
                )
            )
            {
                var recipeDictionary = new Dictionary<int, Rec.Recipe>();

                result = connection
                    .Query<Rec.Recipe, Rec.Ingredient, Rec.Recipe>(
                        sql,
                        (recipe, ingredient) =>
                        {
                            Rec.Recipe recipeEntry;

                            if (!recipeDictionary.TryGetValue(recipe.Id, out recipeEntry))
                            {
                                recipeEntry = recipe;
                                recipeEntry.Ingredients = new List<Rec.Ingredient>();
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

    public interface IRecipeRepository : IRepository<Rec.Recipe>
    {
        IEnumerable<Rec.Recipe> GetAllUserRecipesByUserId(int userId);
    }
}
