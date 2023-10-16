using Recipe.Data.Entities;
using Recipe.Data.UnitOfWork;

namespace Recipe.Services
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

        public void Add(IEnumerable<Ingredient> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.CreatedDate = DateTime.UtcNow;
                ingredient.IsActive = true;
            }

            _unitOfWork.Ingredients.Insert(ingredients);
        }

        public void Update(IEnumerable<Ingredient> ingredients)
        {
            _unitOfWork.Ingredients.Update(ingredients);
        }

        public void Delete(IEnumerable<Ingredient> ingredients)
        {
            _unitOfWork.Ingredients.Delete(ingredients);
        }

        // public void DeleteMultiple(IEnumerable<Ingredient> ingredients)
        // {
        //     _unitOfWork.Ingredients.Delete(ingredients);
        // }
    }

    public interface IIngredientService : IService<Ingredient> { }
}
