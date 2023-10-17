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

        public void Add(IEnumerable<Rec.Recipe> recipes)
        {
            foreach (var recipe in recipes)
            {
                recipe.CreatedDate = DateTime.UtcNow;
                recipe.IsActive = true;
            }

            _unitOfWork.Recipes.Insert(recipes);
        }

        public void Update(IEnumerable<Rec.Recipe> recipes)
        {
            foreach (var recipe in recipes)
            {
                recipe.IsActive = true;
                recipe.CreatedDate = DateTime.UtcNow;
            }
            _unitOfWork.Recipes.Update(recipes);
        }

        public void Delete(IEnumerable<Rec.Recipe> recipes)
        {
            _unitOfWork.Recipes.Delete(recipes);
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
