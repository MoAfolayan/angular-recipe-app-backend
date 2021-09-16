using System;

namespace Recipe.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Auth0Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
