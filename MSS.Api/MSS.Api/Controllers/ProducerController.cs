using Microsoft.AspNetCore.Mvc;

namespace MSS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        private ILogger<ProducerController> Logger { get; set; }

        public ProducerController(ILogger<ProducerController> logger)
        {
            Logger = logger;
        }

        [HttpPost("produce", Name = "ProduceMessage")]
        public IActionResult ProduceMessage([FromBody] string message)
        {
            Console.WriteLine(message);
            return Ok(message);
        }

    }
}
