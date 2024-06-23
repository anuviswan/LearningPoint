using Microsoft.AspNetCore.Mvc;

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
        public Task<IActionResult> CreateUser()
        {
            throw new NotImplementedException();
        }
    }
}
