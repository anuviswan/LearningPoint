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
        [Route("createanimal")]
        public string CreateAnimal(Person person)
        {
            return person.GetType().Name;
        }


        // an attempt using IParsable<T>
        [HttpPost]
        [Route("createshape")]
        public bool CreateShape(Shape shape)
        {
            return true;
        }
    }
}
