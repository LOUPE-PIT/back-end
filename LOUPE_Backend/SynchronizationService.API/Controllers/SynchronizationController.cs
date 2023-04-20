using Microsoft.AspNetCore.Mvc;
using SynchronizationService.Core.API.ViewModels;
using SynchronizationService.Core.API.Strategies;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using SynchronizationService.API.SyncLogService;

namespace SynchronizationService.API.Controllers
{
    [Route("[controller]")]
    public class SynchronizationController : Controller
    {
        private readonly SyncLogService.SyncLogService _syncLogService;

        private readonly Dictionary<string, IActionStrategy> _strategies;

        private readonly Collection<TransformationViewModel> _groupedTransformations = new Collection<TransformationViewModel>();

        public SynchronizationController(IEnumerable<IActionStrategy> strategies, SyncLogService.SyncLogService syncLogService)
        {
            _syncLogService = syncLogService;
            _strategies = strategies.ToDictionary(s => s.Name);
        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SaveSyncronization([FromQuery] string action, [FromBody] TransformationViewModel transformation)
        {
            if (action == string.Empty)
                return BadRequest("No action given");

            try
            {
                if (!_strategies.TryGetValue(action, out IActionStrategy? strategy))
                    return NotFound("Given action not found");

                bool isChanged = await strategy.AddAction(transformation);

                await CheckLastMessage(transformation, isChanged);
            }
            catch (MongoException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok();
        }

        private async Task CheckLastMessage(TransformationViewModel transformation, bool isChanged)
        {
            if(isChanged)
                _groupedTransformations.Add(transformation);

            if (transformation.IsLast)
            {
                await _syncLogService.SendTransformationsToLoggingAsync(_groupedTransformations);

                _groupedTransformations.Clear();
            }
        }
    }
}
