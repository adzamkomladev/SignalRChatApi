using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRChatApi.Data.Dtos.Users;
using SignalRChatApi.Data.Responses;
using SignalRChatApi.Domains;
using SignalRChatApi.Services;

namespace SignalRChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateUserDto body)
        {
            var user = await _userService.CreateAsync(body);

            if (user is null) return BadRequest(new BaseResponse
            {
                Success = false,
                Message = "Username already exists!"
            });

            _logger.LogInformation("CREATION OF USER IS SUCCESSFUL!");

            return Created(nameof(Post), new BaseResponse
            {
                Success = true,
                Data = user
            });
        }
    }
}
