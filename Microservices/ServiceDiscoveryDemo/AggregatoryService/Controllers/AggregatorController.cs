using AggregatoryService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AggregatoryService.Controllers;

[ApiController]
[Route("[controller]")]
public class AggregatorController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IPaymentService _paymentService;
    private readonly ILogger<AggregatorController> _logger;

    public AggregatorController(IUserService userService, IPaymentService paymentService,  ILogger<AggregatorController> logger)
    {
        _logger = logger;
        _userService = userService;
        _paymentService = paymentService;
    }

    [HttpGet]
    public async Task<ActionResult<PaymentDetails?>> Get([FromQuery]string userName)
    {
        var user = await _userService.GetUserByIdAsync(userName).ConfigureAwait(false);
        var paymentDetails = await _paymentService.GetPaymentInfo("123").ConfigureAwait(false);

        return Ok(new PaymentDetails()
        {
            User = user,
            Payment = paymentDetails
        });
    }
}

public record PaymentDetails
{
    public UserDto? User { get; init; }
    public IEnumerable<PaymentInfo>? Payment { get; init; }
}
