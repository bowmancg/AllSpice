namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;

        public RecipesController(RecipesService recipesService)
        {
            _recipesService = recipesService;
        }

        [HttpGet]
        public ActionResult<List<Recipe>> GetRecipes()
        {
            try
            {
                List<Recipe> recipes = _recipesService.GetRecipes();
                return Ok(recipes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}