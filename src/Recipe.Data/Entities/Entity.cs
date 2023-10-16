namespace Recipe.Data.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
