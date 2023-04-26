namespace AllSpice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal List<Recipe> GetRecipes()
        {
            List<Recipe> recipes = _repo.Get();
            return recipes;
        }
    }
}