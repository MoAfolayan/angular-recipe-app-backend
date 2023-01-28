namespace Recipe.Data.Entities
{
    public class User : Entity
    {
        public string Auth0Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
