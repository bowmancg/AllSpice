namespace AllSpice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;

        public IngredientsService(IngredientsRepository repo)
        {
            _repo = repo;
        }

        internal Ingredient CreateIngredient(Ingredient ingredientData)
        {
            Ingredient ingredient = _repo.Insert(ingredientData);
            return ingredient;
        }

        internal List<Ingredient> GetRecipeIngredients(int recipeId)
        {
            List<Ingredient> ingredients = _repo.GetRecipeIngredients(recipeId);
            return ingredients;
        }
    }
}