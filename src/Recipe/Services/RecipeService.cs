using Rec = Recipe.Data.Entities;
using Recipe.Data.UnitOfWork;

namespace Recipe.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Rec.Recipe GetById(int id)
        {
            return _unitOfWork.Recipes.GetById(id);
        }

        public void Add(Rec.Recipe recipe)
        {
            recipe.CreatedDate = DateTime.UtcNow;
            recipe.IsActive = true;
            _unitOfWork.Recipes.Insert(recipe);
        }

        public void Update(Rec.Recipe recipe)
        {
            _unitOfWork.Recipes.Update(recipe);
        }

        public void Delete(Rec.Recipe recipe)
        {
            _unitOfWork.Recipes.Delete(recipe);
        }

        public void DeleteMultiple(IEnumerable<Rec.Recipe> recipes)
        {
            _unitOfWork.Recipes.DeleteMultiple(recipes);
        }

        public IEnumerable<Rec.Recipe> GetAllUserRecipesByUserId(int userId)
        {
            return _unitOfWork.Recipes.GetAllUserRecipesByUserId(userId);
        }
    }

    public interface IRecipeService : IService<Rec.Recipe>
    {
        IEnumerable<Rec.Recipe> GetAllUserRecipesByUserId(int userId);
    }
}
