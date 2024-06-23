using Microsoft.AspNetCore.Mvc;
using NewtonsoftJson.ViewModels;

namespace NewtonsoftJson.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "CreateUser")]
        public IActionResult CreateUser(CreateUserRequest request)
        {

            _logger.LogInformation("Validation Model Successfully");
            return Ok("User created successfully");
        }
    }
}
