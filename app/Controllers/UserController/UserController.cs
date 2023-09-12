using app.Service.UserService;
using Azure.Identity;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers.UserController
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

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var result = await _userService.GetAll();
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsersById(Guid id)
        {
            var result = await _userService.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddNewUser(User user)
        {
            var result = await _userService.AddSingle(user);
            if (result == null) BadRequest();
            return Created(nameof(AddNewUser), user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateSingleUser(Guid id, User updatedUser)
        {
            var result = await _userService.UpdateSingle(id, updatedUser);
            if (result == null) BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleleSingleUser(Guid id)
        {
            try
            {
                var result = await _userService.DeleteById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
