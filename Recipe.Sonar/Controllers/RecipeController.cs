using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using rec = Recipe.Data.Entities;
using Recipe.Logic.Services.Interfaces;

namespace Recipe.Sonar.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class RecipesController : ControllerBase
   {
      private readonly ILogger<RecipesController> _logger;
      private readonly IRecipeService _recipeService;

      public RecipesController(ILogger<RecipesController> logger,
          IRecipeService recipeService)
      {
         _logger = logger;
         _recipeService = recipeService;
      }

      [HttpGet("{id}")]
      [Authorize("read:non-user-entities")]
      public IActionResult Get(int id)
      {
         try
         {
            var recipe = _recipeService.GetById(id);
            return Ok(recipe);
         }
         catch (System.Exception ex)
         {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, ex.Message);
         }
      }

      [HttpPost]
      [Authorize("create:non-user-entities")]
      public IActionResult Add([FromBody] rec.Recipe recipe)
      {
         try
         {
            _recipeService.Add(recipe);
            return Ok();
         }
         catch (System.Exception ex)
         {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, ex.Message);
         }
      }

      [HttpPut]
      [Authorize("update:non-user-entities")]
      public IActionResult Update([FromBody] rec.Recipe recipe)
      {
         try
         {
            _recipeService.Update(recipe);
            return Ok();
         }
         catch (System.Exception ex)
         {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, ex.Message);
         }
      }

      [HttpPost("delete")]
      [Authorize("delete:non-user-entities")]
      public IActionResult Delete([FromBody] IEnumerable<rec.Recipe> recipes)
      {
         try
         {
            _recipeService.DeleteMultiple(recipes);
            return Ok();
         }
         catch (System.Exception ex)
         {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, ex.Message);
         }
      }

      [HttpGet("userid/{userId}")]
      [Authorize("read:non-user-entities")]
      public IActionResult GetAllUserRecipesByUserId(int userId)
      {
         try
         {
            var recipes = _recipeService.GetAllUserRecipesByUserId(userId);
            return Ok(recipes);
         }
         catch (System.Exception ex)
         {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, ex.Message);
         }
      }
   }
}
