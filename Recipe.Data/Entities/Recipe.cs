using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
