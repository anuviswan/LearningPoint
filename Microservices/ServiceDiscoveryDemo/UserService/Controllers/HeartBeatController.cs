using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers;

[ApiController]
[Route("[controller]")]
public class HeartBeatController:ControllerBase
{
    private readonly ILogger<HeartBeatController> _logger;

    public HeartBeatController(ILogger<HeartBeatController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("health")]
    public ActionResult Health()
    {
        return Ok();
    }
}
