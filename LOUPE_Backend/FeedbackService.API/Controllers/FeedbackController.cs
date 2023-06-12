using FeedbackService.Api.Core.Services;
using FeedbackService.API.Core.Viewmodels;
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

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] FeedbackViewmodel feedbackViewmodel)
        {

            await _feedbackService.Create(feedbackViewmodel);

            return Ok();
        }


        [HttpGet("GetById")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var feedback = await _feedbackService.GetById(id);

            return Ok(feedback);
        }

        [HttpGet("GetByUserId")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByUserId(Guid UserId)
        {
            var feedback = await _feedbackService.GetByUserId(UserId);

            return Ok(feedback);
        }

        [HttpGet("GetByLogId")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByLogId(Guid UserId)
        {
            var feedback = await _feedbackService.GetByLogId(UserId);

            return Ok(feedback);
        }

        [HttpDelete("DeleteById")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteById(FeedbackViewmodel feedbackViewmodel)
        {
            await _feedbackService.DeleteById(feedbackViewmodel);
            return Ok();

        }

    }
}
