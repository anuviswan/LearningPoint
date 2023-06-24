using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolymorphicParameterBinding.ModelBinders;
using PolymorphicParameterBinding.Models;

namespace PolymorphicParameterBinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public bool Create(Person person)
        {
            return true;
        }
    }
}
