namespace AllSpice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;
        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Ingredient Insert(Ingredient ingredientData)
        {
            string sql = @"
            INSERT INTO ingredients
            (name, quantity, recipeId, creatorId)
            VALUES
            (@name, @quantity, @recipeId, @creatorId);

            SELECT
            ing.*,
            rec.*,
            creator.*
            FROM ingredients ing
            JOIN recipes rec ON rec.id = ing.recipeId
            JOIN accounts creator ON rec.creatorId = creator.id
            WHERE ing.id = LAST_INSERT_ID();
            ";
            Ingredient ingredient = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, creator) =>
            {
                ingredient.Creator = creator;
                return ingredient;
            }, ingredientData).FirstOrDefault();
            return ingredient;
        }
    }
}