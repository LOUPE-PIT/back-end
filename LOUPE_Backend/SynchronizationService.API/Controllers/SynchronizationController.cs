using Microsoft.AspNetCore.Mvc;
using SynchronizationService.Core.API.ViewModels;

namespace SynchronizationService.API.Controllers
{
    [Route("[controller]")]
    public class SynchronizationController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult AllTransformations()
        {
            return Ok();
        }

        [HttpPost]
        [Route("Test")]
        public IActionResult Test(TransformationViewModel transformation) 
        { 
            return Ok(transformation);
        }
    }
}
