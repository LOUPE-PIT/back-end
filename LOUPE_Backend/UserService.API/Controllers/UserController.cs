using Microsoft.AspNetCore.Mvc;
using UserService.Core.API.Services;
using UserService.DataLayer.Models.User;
using UserService.DataLayer.Services;

namespace UserService.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await _userService.GetUsers());
        }        
        
        [HttpGet("{Id:guid}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid Id, CancellationToken cancellationtoken)
        {
            return Ok(await _userService.GetUserById(Id, cancellationtoken));
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUser(UserModel user)
        {
            return Ok(_userService.AddUser(user));
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser(UserModel user)
        {
            return Ok(_userService.UpdateUser(user));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUserById(Guid Id)
        {
            _userService.DeleteUserById(Id);
            return Ok();
        }
    }
}
