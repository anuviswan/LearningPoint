using Microsoft.AspNetCore.Mvc;

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
    public record PaymentInfo(string UserName, string Amount, string Currency, string Status);
}
