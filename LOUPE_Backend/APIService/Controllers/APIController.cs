using APIService.Core;
using APIService.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {

        private readonly IAPICore _APICore;

        public APIController(IAPICore APIService)
        {
            _APICore = APIService;
        }

        [HttpGet(Name = "GetAll")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var feedback = await _APICore.GetAll();

            return Ok(feedback);
        }

        [HttpGet(Name = "GetById")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var feedback = await _APICore.GetById(id);

            return Ok(feedback);
        }

        [HttpGet(Name = "GetByLogId")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByLogId(Guid logId)
        {
            var feedback = await _APICore.GetByLogId(logId);

            return Ok(feedback);
        }

        [HttpGet(Name = "DeleteById")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            await _APICore.DeleteById(id);
            return Ok();
            
        }

        [HttpGet(Name = "DeleteByLogId")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteByLogId(Guid id)
        {
            await _APICore.DeleteByLogId(id);
            return Ok();
        }
    }
}
