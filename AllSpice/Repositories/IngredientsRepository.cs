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
            ing.*
            FROM ingredients ing
            WHERE ing.recipeId = @recipeId;
            ";
            List<Ingredient> ingredients =  _db.Query<Ingredient>(sql, new { recipeId }).ToList();
            return ingredients;
        }

        internal void Remove(int id)
        {
            string sql = @"
            DELETE FROM ingredients WHERE Id = @Id;
            ";
            _db.Execute(sql, new { id });
        }
    }
}