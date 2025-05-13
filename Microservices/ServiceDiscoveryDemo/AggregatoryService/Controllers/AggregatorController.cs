using Microsoft.AspNetCore.Mvc;

namespace AggregatoryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AggregatorController : ControllerBase
    {
        
        private readonly ILogger<AggregatorController> _logger;

        public AggregatorController(ILogger<AggregatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUserOrders")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(Enumerable.Empty<string>());
        }
    }
}
