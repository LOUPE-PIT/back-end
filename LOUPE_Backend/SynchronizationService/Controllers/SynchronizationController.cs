using Microsoft.AspNetCore.Mvc;
using SynchronizationService.Core.API.ViewModels;
using SynchronizationService.Core.API.Services;
using MongoDB.Driver.Core.Operations;

namespace SynchronizationService.API.Controllers
{
    [Route("[controller]")]
    public class SynchronizationController : Controller
    {
        private readonly SynchronizationCore _synchronizationCore;
        public SynchronizationController(SynchronizationCore core)
        {
            _synchronizationCore = core;
        }

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

            _synchronizationCore.Add(transformation);
            
            return Ok();
        }
    }
}
