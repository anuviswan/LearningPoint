using AggregatoryService.Services;
using Microsoft.AspNetCore.Mvc;
using static AggregatoryService.Services.UserService;

namespace AggregatoryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AggregatorController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AggregatorController> _logger;

        public AggregatorController(IUserService userService, ILogger<AggregatorController> logger)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet(Name = "GetUserOrders")]
        public ActionResult<UserDto?> Get()
        {
            var userId = _userService.GetUserByIdAsync("123").Result;
            return Ok(userId);
        }
    }
}
