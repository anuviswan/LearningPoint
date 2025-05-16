using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetPaymentInfo")]
        public ActionResult<IEnumerable<PaymentInfo>> Get([FromQuery]string userName)
        {
            var result = Enumerable.Range(1,10).Select(
                index => new PaymentInfo(userName, (index * 10).ToString(), "USD", "Success")
            );

            return Ok(result);
        }
    }
    public record PaymentInfo(
        [property: JsonPropertyName("userName")] string UserName, [property: JsonPropertyName("amount")] string Amount,
        [property: JsonPropertyName("currency")] string Currency, [property: JsonPropertyName("status")] string Status);
}
