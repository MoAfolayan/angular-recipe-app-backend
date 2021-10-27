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
    public class CheckListItemController : ControllerBase
    {
        private readonly ILogger<CheckListItemController> _logger;
        private readonly ICheckListItemService _checkListItemService;

        public CheckListItemController(ILogger<CheckListItemController> logger,
            ICheckListItemService checkListItemService)
        {
            _logger = logger;
            _checkListItemService = checkListItemService;
        }

        [HttpGet("{id}")]
        [Authorize("read:non-user-entities")]
        public IActionResult Get(int id)
        {
            var checkListItem = _checkListItemService.GetById(id);
            return Ok(checkListItem);
        }

        [HttpPost]
        [Authorize("create:non-user-entities")]
        public IActionResult Add([FromBody] CheckListItem checkListItem)
        {
            _checkListItemService.Add(checkListItem);
            return Ok();
        }

        [HttpPut]
        [Authorize("update:non-user-entities")]
        public IActionResult Update([FromBody] CheckListItem checkListItem)
        {
            _checkListItemService.Update(checkListItem);
            return Ok();
        }

        [HttpDelete]
        [Authorize("delete:non-user-entities")]
        public IActionResult Delete([FromBody] CheckListItem checkListItem)
        {
            _checkListItemService.Delete(checkListItem);
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
