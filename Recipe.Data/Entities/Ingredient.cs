using System;

namespace Recipe.Data.Entities
{
    public class Ingredient : Entity
    {
        public string Name { get; set; }
        public int RecipeId { get; set; }
    }
}
