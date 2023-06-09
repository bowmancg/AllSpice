namespace AllSpice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;
        private readonly IngredientsService _ingredientsService;

        public RecipesService(RecipesRepository repo, IngredientsService ingredientsService)
        {
            _repo = repo;
            _ingredientsService = ingredientsService;
        }


        internal Recipe CreateRecipe(Recipe recipeData)
        {
            Recipe recipe = _repo.Insert(recipeData);
            return recipe;
        }
        internal List<Recipe> GetRecipes()
        {
            List<Recipe> recipes = _repo.Get();
            return recipes;
        }

        internal Recipe GetOne(int recipeId)
        {
            Recipe recipe = _repo.GetOne(recipeId);
            if (recipe == null) throw new Exception($"Bad Id: {recipeId}");
            return recipe;
        }

        internal Recipe EditRecipe(Recipe recipeData, int recipeId)
        {
            Recipe originalRecipe = this.GetOne(recipeId);
            originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
            originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
            originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;
            originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;
            _repo.EditRecipe(originalRecipe);
            originalRecipe.UpdatedAt = DateTime.Now;
            return originalRecipe;
        }

        internal string Remove(int recipeId)
        {
            Recipe recipe = this.GetOne(recipeId);
            int rowsAffected = _repo.Remove(recipeId);
            if (rowsAffected == 0)
            {
                throw new Exception("Delete failed.");
            }
            if (rowsAffected > 1)
            {
                throw new Exception("Something went wrong.");
            }
            return $"{recipe.Title} has been removed.";
        }

        internal List<Ingredient> GetRecipeIngredients(int recipeId)
        {
            List<Ingredient> ingredients = _ingredientsService.GetRecipeIngredients(recipeId);
            return ingredients;
        }

        internal List<Recipe> Get(string query)
        {
            List<Recipe> recipes = _repo.GetAll(query);
            return recipes;
        }
    }
}