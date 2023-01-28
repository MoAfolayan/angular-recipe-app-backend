using System.Collections.Generic;

namespace Recipe.Data.Entities
{
    public class Recipe : Entity
    {
        public string Name { get; set; }
        public int UserId { get; set; }

        //not in database
        public List<Ingredient> Ingredients { get; set; }
    }
}
