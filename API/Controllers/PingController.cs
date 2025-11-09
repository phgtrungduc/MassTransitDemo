using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLib;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IBus _bus;
        public PingController(IBus bus)
        {
                _bus = bus;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var data = new DemoEvent() { Name = "Pinged at " + DateTime.UtcNow, Value = "Some Value" };
            _bus.Publish(data);
            return Ok("Pong");
        }
    }
}
