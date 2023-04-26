namespace AllSpice.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        public List<Recipe> Get()
        {
            string sql = @"
            SELECT
            rec.*
            creator.*
            FROM recipes rec
            JOIN accounts creator ON creator.id = rec.creatorId;
            ";
            List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) => {
                recipe.Creator = creator;
                return recipe;
            }).ToList();
            return recipes;
        }
    }
}