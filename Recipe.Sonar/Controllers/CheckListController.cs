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
    public class CheckListController : ControllerBase
    {
        private readonly ILogger<CheckListController> _logger;
        private readonly ICheckListService _checkListService;

        public CheckListController(ILogger<CheckListController> logger,
            ICheckListService checkListService)
        {
            _logger = logger;
            _checkListService = checkListService;
        }

        [HttpGet("{id}")]
        [Authorize("read:non-user-entities")]
        public IActionResult Get(int id)
        {
            var user = _checkListService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        [Authorize("create:non-user-entities")]
        public IActionResult Add([FromBody] CheckList checkList)
        {
            _checkListService.Add(checkList);
            return Ok();
        }

        [HttpPut]
        [Authorize("update:non-user-entities")]
        public IActionResult Update([FromBody] CheckList checkList)
        {
            _checkListService.Update(checkList);
            return Ok();
        }

        [HttpDelete]
        [Authorize("delete:non-user-entities")]
        public IActionResult Delete([FromBody] CheckList checkList)
        {
            _checkListService.Delete(checkList);
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
