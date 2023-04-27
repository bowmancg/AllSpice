namespace AllSpice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;
        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        // internal Ingredient Insert(Ingredient ingredientData)
        // {
        //     string sql = @"
        //     INSERT INTO ingredients
        //     (name, quantity, recipeId)
        //     VALUES
        //     (@name, @quantity, @recipeId);

        //     SELECT
        //     ing.*,
        //     recipe.*
        //     FROM ingredients ing
        //     JOIN 
        //     ";
        // }
    }
}