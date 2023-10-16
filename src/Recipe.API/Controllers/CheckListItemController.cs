using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Recipe.Data.Entities;
using Recipe.Services;

namespace Recipe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckListItemController : ControllerBase
    {
        private readonly ILogger<CheckListItemController> _logger;
        private readonly ICheckListItemService _checkListItemService;

        public CheckListItemController(
            ILogger<CheckListItemController> logger,
            ICheckListItemService checkListItemService
        )
        {
            _logger = logger;
            _checkListItemService = checkListItemService;
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "read:non-user-entities")]
        public IActionResult Get(int id)
        {
            try
            {
                var checkListItem = _checkListItemService.GetById(id);
                return Ok(checkListItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Policy = "create:non-user-entities")]
        public IActionResult Add([FromBody] CheckListItem checkListItem)
        {
            try
            {
                _checkListItemService.Add(checkListItem);
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
        public IActionResult Update([FromBody] CheckListItem checkListItem)
        {
            try
            {
                _checkListItemService.Update(checkListItem);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(Policy = "delete:non-user-entities")]
        public IActionResult Delete([FromBody] CheckListItem checkListItem)
        {
            try
            {
                _checkListItemService.Delete(checkListItem);
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
