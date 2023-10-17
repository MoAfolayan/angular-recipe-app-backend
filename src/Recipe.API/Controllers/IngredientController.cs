using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Recipe.Data.Entities;
using Recipe.Services;

namespace Recipe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly ILogger<IngredientController> _logger;
        private readonly IIngredientService _ingredientService;

        public IngredientController(
            ILogger<IngredientController> logger,
            IIngredientService ingredientService
        )
        {
            _logger = logger;
            _ingredientService = ingredientService;
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "read:non-user-entities")]
        public IActionResult Get(int id)
        {
            try
            {
                var ingredient = _ingredientService.GetById(id);
                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Policy = "create:non-user-entities")]
        public IActionResult Add([FromBody] IEnumerable<Ingredient> ingredient)
        {
            try
            {
                _ingredientService.Add(ingredient);
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
        public IActionResult Update([FromBody] IEnumerable<Ingredient> ingredient)
        {
            try
            {
                _ingredientService.Update(ingredient);
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
        public IActionResult Delete([FromBody] IEnumerable<Ingredient> ingredients)
        {
            try
            {
                _ingredientService.Delete(ingredients);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
