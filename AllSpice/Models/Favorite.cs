namespace AllSpice.Models
{
    public class Favorite : RepoItem<int>
    {
        public string FavoriteId { get; set; }
        public string AccountId { get; set; }
        public int RecipeId { get; set; }
    }
}