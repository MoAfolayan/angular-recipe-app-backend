using System;
using Recipe.Data.Entities;
using Recipe.Data.Repositories;
using Recipe.Data.Repositories.Interfaces;
using Recipe.Data.UnitOfWork.Interfaces;

namespace Recipe.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IUserRepository userRepository,
            IRecipeRepository recipeRepository,
            IIngredientRepository ingredientRepository,
            ICheckListRepository checkListRepository,
            ICheckListItemRepository checkListItemRepository)
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
}
