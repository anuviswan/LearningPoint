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
        
        var response = await _mediator.SendRequest(new OrderSubmitCommand
        {
            Id = id,
            CustomerId = customerId,
            TimeStamp = DateTime.UtcNow
        });


        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }
}
