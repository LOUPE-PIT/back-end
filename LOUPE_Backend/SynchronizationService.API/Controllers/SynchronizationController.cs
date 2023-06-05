using Microsoft.AspNetCore.Mvc;
using SynchronizationService.Core.API.ViewModels;
using SynchronizationService.Core.API.Strategies;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using Timer = System.Timers.Timer;
using SynchronizationService.API.Hubs;
using SynchronizationService.API.Hubs.Messages;

namespace SynchronizationService.API.Controllers
{
    [Route("[controller]s")]
    public class SynchronizationController : Controller
    {
        private readonly SyncLogService.SyncLogService _syncLogService;

        private readonly Dictionary<string, IActionStrategy> _strategies;
        private readonly SynchronizationHub _synchronizationMessaging;

        private readonly int transformationLimit = 12;

        private static readonly Collection<TransformationViewModel> _groupedTransformations = new Collection<TransformationViewModel>();

        private static readonly Timer eventTimer = new Timer();

        public SynchronizationController(IEnumerable<IActionStrategy> strategies, SyncLogService.SyncLogService syncLogService, SynchronizationHub synchronizationMessaging)
        {
            _syncLogService = syncLogService;
            _strategies = strategies.ToDictionary(s => s.Name);
            _synchronizationMessaging = synchronizationMessaging;

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

                if (await strategy.AddAction(transformation))
                    _groupedTransformations.Add(transformation);

                await CheckGroupsTransformationSize(transformation);
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

        private async Task CheckGroupsTransformationSize(TransformationViewModel transformation)
        {
            List<TransformationViewModel> transfomrationsForGroup = _groupedTransformations.Where(tr => tr.GroupId == transformation.GroupId).ToList();
            if (transfomrationsForGroup.Count >= transformationLimit)
            {
                await FireEvent(transformation.GroupId);
            }
        }

        private async void TimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            await FireEvent();
        }

        private async Task FireEvent()
        {
            List<List<TransformationViewModel>> GroupedTransformationPerGroup = new();

            List<Guid> GroupIds = _groupedTransformations.Select(tr => tr.GroupId).Distinct().ToList();

            foreach(Guid id in GroupIds)
            {
                GroupedTransformationPerGroup.Add(_groupedTransformations.Where(tr => tr.GroupId == id).ToList());
            }

            foreach(List<TransformationViewModel> synchronizations in GroupedTransformationPerGroup)
            {
                await _syncLogService.SendTransformationsToLoggingAsync(new Collection<TransformationViewModel>(synchronizations));
                SendMessages(synchronizations[^1]);
            }

            _groupedTransformations.Clear();
        }

        private async Task FireEvent(Guid GroupId)
        {
            Collection<TransformationViewModel> transformations = new(_groupedTransformations.Where(tr => tr.GroupId == GroupId).ToList());

            await _syncLogService.SendTransformationsToLoggingAsync(transformations);
            SendMessages(transformations[^1]);

            _groupedTransformations.Clear();
        }

        private async Task SendMessages(TransformationViewModel lastTransformation)
        {
            SynchronizationMessage message = new SynchronizationMessage() { ObjectName = lastTransformation.ActionType.ObjectName, NewPosition = new MyNumbers(lastTransformation.ActionType.XPos ?? -1, lastTransformation.ActionType.YPos ?? -1, lastTransformation.ActionType.ZPos ?? -1), DegreesRotation = lastTransformation.ActionType.Degrees ?? -1 };
            _synchronizationMessaging.ReceiveSynchronization(message, lastTransformation.GroupId);
        }
    }
}
