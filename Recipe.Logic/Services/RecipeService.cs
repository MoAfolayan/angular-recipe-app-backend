using System;
using System.Collections.Generic;
using rec = Recipe.Data.Entities;
using Recipe.Data.UnitOfWork;

namespace Recipe.Logic.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public rec.Recipe GetById(int id)
        {
            return _unitOfWork.Recipes.GetById(id);
        }

        public void Add(rec.Recipe recipe)
        {
            recipe.CreatedDate = DateTime.UtcNow;
            recipe.IsActive = true;
            _unitOfWork.Recipes.Insert(recipe);
        }

        public void Update(rec.Recipe recipe)
        {
            _unitOfWork.Recipes.Update(recipe);
        }

        public void Delete(rec.Recipe recipe)
        {
            _unitOfWork.Recipes.Delete(recipe);
        }

        public void DeleteMultiple(IEnumerable<rec.Recipe> recipes)
        {
            _unitOfWork.Recipes.DeleteMultiple(recipes);
        }

        public IEnumerable<rec.Recipe> GetAllUserRecipesByUserId(int userId)
        {
            return _unitOfWork.Recipes.GetAllUserRecipesByUserId(userId);
        }
    }

    public interface IRecipeService : IService<rec.Recipe>
    {
        IEnumerable<rec.Recipe> GetAllUserRecipesByUserId(int userId);
    }
}
