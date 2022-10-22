using MassTransit.MediatR.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.Mediator.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    private readonly IRequestClient<IOrderSubmit> _submitOrderRequestClient;
    public DemoController(IRequestClient<IOrderSubmit> submitOrderRequestClient)
    {
        _submitOrderRequestClient = submitOrderRequestClient;
    }
    [HttpPost]
    public async Task<IActionResult> PlaceOrder(Guid id,Guid customerId)
    {
        var (accepted,rejected) = await _submitOrderRequestClient.GetResponse<IOrderSubmitAccepted,IOrderSubmitRejected>(new
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
