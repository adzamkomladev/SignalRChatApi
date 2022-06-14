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
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUsersFilterDto query)
        {
            _logger.LogInformation("GET ALL USERS FILTERED");

            return Ok(new BaseResponse
            {
                Success = true,
                Data = await _userService.GetAllUsersFilteredAndPaginated(query)
            });
        }
    }
}
