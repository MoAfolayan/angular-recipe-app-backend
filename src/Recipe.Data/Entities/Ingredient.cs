using Dapper.Contrib.Extensions;

namespace Recipe.Data.Entities
{
    [Table("Ingredient")]
    public class Ingredient : Entity
    {
        public string Name { get; set; }
        public int RecipeId { get; set; }

        //not in database
        public Recipe Recipe { get; set; }
    }
}
