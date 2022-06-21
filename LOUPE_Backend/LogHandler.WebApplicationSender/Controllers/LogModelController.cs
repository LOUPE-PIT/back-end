using LogHandler.Microservice.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationLogSender.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogModelController : ControllerBase
    {
        // Endpoint Interface;
        private readonly IPublishEndpoint publishEndpoint;

        public LogModelController(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        // Since the controller doesn't have any calls, this will be the base call. You can call this by connection to: [localhost:port]/api/order; 
        [HttpPost]
        public async Task<ActionResult> Create(LogModel log)
        {
            // The publish endpoint publishes the message into [model] exchange, the [model] exchange passes it to [model] queue. 
            await publishEndpoint.Publish<LogModel>(log);
            return Ok();
        }
    }
}
