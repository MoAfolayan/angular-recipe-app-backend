using System;

namespace Recipe.Data.Entities
{
    public class Recipe : Entity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
