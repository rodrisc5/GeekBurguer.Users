using GeekBurguer.Users.Contracts.Commands.Input;
using GeekBurguer.Users.Contracts.Commands.Output;
using GeekBurguer.Users.ServiceBus;
using GeekBurguer.Users.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GeekBurguer.Users.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("api/user")]
        [ProducesResponseType(typeof(OutputUserFaceCommand), StatusCodes.Status200OK)]
        public IActionResult Face([FromBody] InputUserFaceCommand inputFace)
        {
            return Ok(new OutputUserFaceCommand()
            {
                Processing = true,
                UserId = Guid.NewGuid(),
            });
        }

        [HttpPost("api/users/foodRestrictions")]
        [ProducesResponseType(typeof(OutputUserFoodRestrictionsCommand), StatusCodes.Status200OK)]
        public async Task<IActionResult> FoodRestrictions([FromBody] InputUserFoodRestrictionsCommand foodRestrictions)
        {
            var result = await _userService.SendMessageUserFoodRestriction(foodRestrictions);
            if (result.Data is not null) 
                return Ok(result);
            else
                return BadRequest(result.Errors);
        }
    }
}
