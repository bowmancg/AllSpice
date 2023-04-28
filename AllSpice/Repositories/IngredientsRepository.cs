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
            (name, quantity, recipeId)
            VALUES
            (@name, @quantity, @recipeId);

            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, ingredientData);
            ingredientData.Id = id;
            ingredientData.CreatedAt = DateTime.Now;
            ingredientData.UpdatedAt = DateTime.Now;
            return ingredientData;

        }

        internal List<Ingredient> GetRecipeIngredients(int recipeId)
        {
            string sql = @"
            SELECT
            ing.*,
            acct.*
            FROM ingredients ing
            JOIN accounts acct ON ing.creatorId = account.id
            WHERE ing.recipeId = @recipeId;
            ";
            return _db.Query<Ingredient, Account, Ingredient>(sql, (ing, account) =>
            {
            //  cast the creator to the ingredient to be returned
                return ing;
            }, new { recipeId }).ToList();
        }
    }
}