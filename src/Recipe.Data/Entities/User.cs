using Dapper.Contrib.Extensions;

namespace Recipe.Data.Entities
{
    [Table("User")]
    public class User : Entity
    {
        public string Auth0Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
