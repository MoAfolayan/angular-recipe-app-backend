using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Recipe.Data.Entities;
using Recipe.Services;

namespace Recipe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Policy = "read:users")]
        public IActionResult Get()
        {
            try
            {
                var subClaim = User.Claims
                    .Where(
                        x =>
                            x.Type.Equals(
                                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
                            )
                    )
                    .FirstOrDefault()
                    .Value;
                var user = _userService.GetUserByAuth0Id(subClaim);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Policy = "create:users")]
        public IActionResult Add([FromBody] User user)
        {
            try
            {
                _userService.Add(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Policy = "update:users")]
        public IActionResult Update([FromBody] User user)
        {
            try
            {
                _userService.Update(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(Policy = "delete:users")]
        public IActionResult Delete([FromBody] User user)
        {
            try
            {
                _userService.Delete(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("claims")]
        public IActionResult Claims()
        {
            try
            {
                return Ok(User.Claims.Select(c => new { c.Type, c.Value }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
