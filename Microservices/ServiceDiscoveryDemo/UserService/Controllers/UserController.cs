using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("GetUserInfo")]
    public ActionResult<UserInfo> Get([FromQuery]string userName)
    {
        return Ok(new UserInfo("John Doe","1234456","john.doe@gmail.com"));
    }
}

public record UserInfo(string Name,string Phone,string Email);
