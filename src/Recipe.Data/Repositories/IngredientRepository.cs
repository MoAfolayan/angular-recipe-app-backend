using Recipe.Data.Entities;
using Microsoft.Extensions.Configuration;

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

    public interface IIngredientRepository : IRepository<Ingredient> { }
}
