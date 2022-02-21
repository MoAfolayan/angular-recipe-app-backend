using Recipe.Data.Repositories;
using Recipe.Data.Repositories.Interfaces;

namespace Recipe.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRecipeRepository Recipes { get; }
        IIngredientRepository Ingredients { get; }
        ICheckListRepository CheckLists { get; }
        ICheckListItemRepository CheckListItems { get; }
    }
}