using Microsoft.AspNetCore.Mvc;
using SynchronizationService.Core.API.ViewModels;
using SynchronizationService.Core.API.Strategies;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using Timer = System.Timers.Timer;

namespace SynchronizationService.API.Controllers
{
    [Route("[controller]")]
    public class SynchronizationController : Controller
    {
        private readonly SyncLogService.SyncLogService _syncLogService;

        private readonly Dictionary<string, IActionStrategy> _strategies;

        private static readonly Collection<TransformationViewModel> _groupedTransformations = new Collection<TransformationViewModel>();

        private static Timer eventTimer = new Timer();

        public SynchronizationController(IEnumerable<IActionStrategy> strategies, SyncLogService.SyncLogService syncLogService)
        {
            _syncLogService = syncLogService;
            _strategies = strategies.ToDictionary(s => s.Name);

            eventTimer.Interval = 2000;
            eventTimer.Elapsed += TimerElapsed;
            eventTimer.Enabled = true;
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

            transformation.Id = Guid.NewGuid();
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

        private void TimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Event fired at {0}", e.SignalTime);
        }
    }
}
