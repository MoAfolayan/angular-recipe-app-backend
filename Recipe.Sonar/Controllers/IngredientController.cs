using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Recipe.Data.Entities;
using Recipe.Logic.Services.Interfaces;

namespace Recipe.Sonar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly ILogger<IngredientController> _logger;
        private readonly IIngredientService _ingredientService;

        public IngredientController(ILogger<IngredientController> logger,
            IIngredientService ingredientService)
        {
            _logger = logger;
            _ingredientService = ingredientService;
        }

        [HttpGet("{id}")]
        [Authorize("read:non-user-entities")]
        public IActionResult Get(int id)
        {
            var ingredient = _ingredientService.GetById(id);
            return Ok(ingredient);
        }

        [HttpPost]
        [Authorize("create:non-user-entities")]
        public IActionResult Add([FromBody] Ingredient ingredient)
        {
            _ingredientService.Add(ingredient);
            return Ok();
        }

        [HttpPut]
        [Authorize("update:non-user-entities")]
        public IActionResult Update([FromBody] Ingredient ingredient)
        {
            _ingredientService.Update(ingredient);
            return Ok();
        }

        [HttpDelete]
        [Authorize("delete:non-user-entities")]
        public IActionResult Delete([FromBody] Ingredient ingredient)
        {
            _ingredientService.Delete(ingredient);
            return Ok();
        }

        [HttpGet("claims")]
        [Authorize]
        public IActionResult Claims()
        {
            return Ok(User.Claims.Select(c => new { c.Type, c.Value }));
        }
    }
}
