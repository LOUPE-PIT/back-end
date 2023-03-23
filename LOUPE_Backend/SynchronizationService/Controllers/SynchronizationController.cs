using Microsoft.AspNetCore.Mvc;
using SynchronizationService.Core.API.ViewModels;
using SynchronizationService.Core.API.ViewModels.Actions;

namespace SynchronizationService.API.Controllers
{
    [Route("[controller]")]
    public class SynchronizationController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult AllTransformations()
        {
            return Ok();
        }

        [HttpPost("Test")]
        public IActionResult Test([FromQuery]string action, [FromBody]TransformationViewModel transformation) 
        {
            //--> action strategy
            if (action == string.Empty)
                return BadRequest();
            
            return Ok();
        }
    }
}
