using CqrsAndMediatR.Domain.Entities;
using CqrsAndMediatR.Service.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsAndMediatR.Api.Controllers
{
    [ApiController]
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            return await _mediator.Send(new GetCustomersQuery());
        }
    }
}
