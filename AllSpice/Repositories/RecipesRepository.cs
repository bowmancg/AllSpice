namespace AllSpice.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }


        internal Recipe Insert(Recipe recipeData)
        {
            string sql = @"
            INSERT INTO recipes
            (title, instructions, img, category, creatorId)
            VALUES
            (@title, @instructions, @img, @category, @creatorId);

            SELECT
            rec.*,
            creator.*
            FROM recipes rec
            JOIN accounts creator ON creator.id = rec.creatorId
            WHERE rec.id = LAST_INSERT_ID();
            ";
            Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql,(recipe, creator) =>
            {
                recipe.Creator = creator;
                return recipe;
            }, recipeData).FirstOrDefault();

            return recipe;
        }
        public List<Recipe> Get()
        {
            string sql = @"
            SELECT
            rec.*,
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

        public Recipe GetOne(int id)
        {
            string sql = @"
            SELECT
            rec.*,
            creator.*
            FROM recipes rec
            JOIN accounts creator ON creator.id = rec.creatorId
            WHERE rec.id = @id;
            ";
            Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>{
                recipe.Creator = creator;
                return recipe;
            }, new { id }).FirstOrDefault();
            return recipe;
        }

        internal void EditRecipe(Recipe originalRecipe)
        {
            string sql = @"
            UPDATE recipes
            SET
            title = @Title,
            instructions = @Instructions,
            img = @Img,
            category = @Category
            WHERE id = @Id;
            ";
            _db.Execute(sql, originalRecipe);
        }

        internal int Remove(int recipeId)
        {
            string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";
            int rowsAffected = _db.Execute(sql, new { recipeId });
            return rowsAffected;
        }
    }
}