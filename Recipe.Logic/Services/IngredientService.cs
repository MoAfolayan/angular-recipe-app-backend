using System;
using System.Collections.Generic;
using Recipe.Data.Entities;
using Recipe.Data.UnitOfWork;

namespace Recipe.Logic.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IngredientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Ingredient GetById(int id)
        {
            return _unitOfWork.Ingredients.GetById(id);
        }

        public void Add(Ingredient ingredient)
        {
            ingredient.CreatedDate = DateTime.UtcNow;
            ingredient.IsActive = true;
            _unitOfWork.Ingredients.Insert(ingredient);
        }

        public void Update(Ingredient ingredient)
        {
            _unitOfWork.Ingredients.Update(ingredient);
        }

        public void Delete(Ingredient ingredient)
        {
            _unitOfWork.Ingredients.Delete(ingredient);
        }

        public void DeleteMultiple(IEnumerable<Ingredient> ingredients)
        {
            _unitOfWork.Ingredients.DeleteMultiple(ingredients);
        }
    }

    public interface IIngredientService : IService<Ingredient>
    {
    }
}
