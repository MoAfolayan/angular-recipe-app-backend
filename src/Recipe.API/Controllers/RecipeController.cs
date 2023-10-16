using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rec = Recipe.Data.Entities;
using Recipe.Services;

namespace Recipe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;
        private readonly IRecipeService _recipeService;

        public RecipesController(ILogger<RecipesController> logger, IRecipeService recipeService)
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
        public IActionResult Add([FromBody] Rec.Recipe recipe)
        {
            try
            {
                _recipeService.Add(recipe);
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
        public IActionResult Update([FromBody] Rec.Recipe recipe)
        {
            try
            {
                _recipeService.Update(recipe);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("delete-multiple")]
        [Authorize(Policy = "delete:non-user-entities")]
        public IActionResult DeleteMultiple([FromBody] IEnumerable<Rec.Recipe> recipes)
        {
            try
            {
                _recipeService.DeleteMultiple(recipes);
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
        public IActionResult Delete([FromBody] Rec.Recipe recipe)
        {
            try
            {
                _recipeService.Delete(recipe);
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
