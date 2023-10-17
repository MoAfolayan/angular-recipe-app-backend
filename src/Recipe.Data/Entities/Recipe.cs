using Dapper.Contrib.Extensions;

namespace Recipe.Data.Entities
{
    [Table("Recipe")]
    public class Recipe : Entity
    {
        public string Name { get; set; }
        public int UserId { get; set; }

        [Write(false)]
        public List<Ingredient>? Ingredients { get; set; }
    }
}
