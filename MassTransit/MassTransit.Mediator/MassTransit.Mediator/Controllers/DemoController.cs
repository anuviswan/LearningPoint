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
        var response = await _submitOrderRequestClient.GetResponse<IOrderSubmitAccepted>(new
        {
            Id = id,
            CustomerId = customerId,
            TimeStamp = DateTime.UtcNow
        });
        return Ok(response.Message);
    }
}
