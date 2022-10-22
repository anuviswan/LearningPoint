using MassTransit.MediatR.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.Mediator.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    private readonly IMediator _mediator;
    public DemoController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> PlaceOrder(Guid id,Guid customerId)
    {
        
        var (accepted,rejected) = await _mediator.CreateRequestClient<IOrderSubmit>()
            .GetResponse<IOrderSubmitAccepted,IOrderSubmitRejected>(new
        {
            Id = id,
            CustomerId = customerId,
            TimeStamp = DateTime.UtcNow
        });

        if (accepted.IsCompletedSuccessfully)
        {
            var acceptResponse = await accepted;
            return Accepted(acceptResponse.Message);

        }

        var rejectResponse = await rejected;
        return BadRequest(rejectResponse.Message);
    }
}
