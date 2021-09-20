using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Recipe.Data.Entities;
using Recipe.Logic.Services;

namespace Recipe.Sonar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [Authorize("read:users")]
        public IActionResult Get()
        {
            var user = _userService.GetUserByAuth0Id(User.Identity.Name);
            return Ok(user);
        }

        [HttpPost]
        [Authorize("create:users")]
        public IActionResult Add([FromBody] User user)
        {
            _userService.AddUser(user);
            return Ok();
        }

        [HttpPut]
        [Authorize("update:users")]
        public IActionResult Update([FromBody] User user)
        {
            _userService.UpdateUser(user);
            return Ok();
        }

        [HttpDelete]
        [Authorize("delete:users")]
        public IActionResult Delete([FromBody] User user)
        {
            _userService.DeleteUser(user);
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
