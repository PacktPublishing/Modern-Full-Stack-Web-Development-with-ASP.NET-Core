using Microsoft.AspNetCore.Mvc;

namespace Chapter03.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        [HttpGet]

        public IActionResult Get()

        {

            throw new InvalidOperationException("This is a test exception.");

        }

    }
}
