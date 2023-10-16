namespace Recipe.Data.Entities
{
    public class CheckListItem : Entity
    {
        public int CheckListId { get; set; }
        public int RecipeId { get; set; }
        public bool IsChecked { get; set; }
    }
}
