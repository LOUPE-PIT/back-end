using FeedbackService.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var feedback = await _feedbackService.GetAll();

            return Ok(feedback);
        }


        /*
                    [HttpGet(Name = "GetById")]
                    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
                    public async Task<IActionResult> GetById(Guid id)
                    {
                        var feedback = await _feedbackService.GetById(id);

                        return Ok(feedback);
                    }

                    [HttpGet(Name = "GetByLogId")]
                    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
                    public async Task<IActionResult> GetByLogId(Guid logId)
                    {
                        var feedback = await _feedbackService.GetByLogId(logId);

                        return Ok(feedback);
                    }

                    [HttpGet(Name = "DeleteById")]
                    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
                    public async Task<IActionResult> DeleteById(Guid id)
                    {
                        await _feedbackService.DeleteById(id);
                        return Ok();

                    }

                    [HttpGet(Name = "DeleteByLogId")]
                    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
                    public async Task<IActionResult> DeleteByLogId(Guid id)
                    {
                        await _feedbackService.DeleteByLogId(id);
                        return Ok();
                    }*/
    }
}
