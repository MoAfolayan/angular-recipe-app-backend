using Recipe.Data.Repositories;

namespace Recipe.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IUserRepository userRepository,
            IRecipeRepository recipeRepository,
            IIngredientRepository ingredientRepository
        )
        {
            Users = userRepository;
            Recipes = recipeRepository;
            Ingredients = ingredientRepository;
        }

        public IUserRepository Users { get; }
        public IRecipeRepository Recipes { get; }
        public IIngredientRepository Ingredients { get; }
    }

    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRecipeRepository Recipes { get; }
        IIngredientRepository Ingredients { get; }
    }
}
