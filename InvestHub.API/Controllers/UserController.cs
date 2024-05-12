using InvestHub.Core.Dto;
using InvestHub.Core.Entities;
using InvestHub.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvestHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto request)
        {
            try
            {
                _userService.CreateUser(request);
                return Ok("User created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet()]
        public IActionResult GetUserList([FromQuery]UserType userType)
        {
            try
            {
                var user = _userService.GetUsers(userType);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{UserId}")]
        public IActionResult GetUser(string userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{userId}")]
        public IActionResult UpdateUser(string userId, [FromBody] string NewUsername)
        {
            try
            {
                _userService.UpdateUser(userId, NewUsername);
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(string userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
