using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rec = Recipe.Data.Entities;
using Recipe.Services;

namespace Recipe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeService _recipeService;

        public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "read:non-user-entities")]
        public IActionResult Get(int id)
        {
            try
            {
                var recipe = _recipeService.GetById(id);
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Policy = "create:non-user-entities")]
        public IActionResult Add([FromBody] IEnumerable<Rec.Recipe> recipes)
        {
            try
            {
                _recipeService.Add(recipes);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Policy = "update:non-user-entities")]
        public IActionResult Update([FromBody] IEnumerable<Rec.Recipe> recipes)
        {
            try
            {
                _recipeService.Update(recipes);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("delete")]
        [Authorize(Policy = "delete:non-user-entities")]
        public IActionResult Delete([FromBody] IEnumerable<Rec.Recipe> recipes)
        {
            try
            {
                _recipeService.Delete(recipes);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("userid/{userId}")]
        [Authorize(Policy = "read:non-user-entities")]
        public IActionResult GetAllUserRecipesByUserId(int userId)
        {
            try
            {
                var recipes = _recipeService.GetAllUserRecipesByUserId(userId);
                return Ok(recipes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
