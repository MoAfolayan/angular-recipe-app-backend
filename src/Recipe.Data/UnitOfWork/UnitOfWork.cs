using Recipe.Data.Repositories;

namespace Recipe.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IUserRepository userRepository,
            IRecipeRepository recipeRepository,
            IIngredientRepository ingredientRepository,
            ICheckListRepository checkListRepository,
            ICheckListItemRepository checkListItemRepository
        )
        {
            Users = userRepository;
            Recipes = recipeRepository;
            Ingredients = ingredientRepository;
            CheckLists = checkListRepository;
            CheckListItems = checkListItemRepository;
        }

        public IUserRepository Users { get; }
        public IRecipeRepository Recipes { get; }
        public IIngredientRepository Ingredients { get; }
        public ICheckListRepository CheckLists { get; }
        public ICheckListItemRepository CheckListItems { get; }
    }

    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRecipeRepository Recipes { get; }
        IIngredientRepository Ingredients { get; }
        ICheckListRepository CheckLists { get; }
        ICheckListItemRepository CheckListItems { get; }
    }
}
