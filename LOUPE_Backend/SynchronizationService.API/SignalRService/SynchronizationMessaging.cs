using Microsoft.AspNetCore.SignalR;
using SynchronizationService.API.Hub;
using SynchronizationService.Core.API.ViewModels;
using System.Numerics;

namespace SynchronizationService.API.SignalRService
{
    public class SynchronizationMessaging
    {
        private readonly IHubContext<SynchronizationHub, ISynchronizationHub> _synchronizationHub;

        public SynchronizationMessaging(IHubContext<SynchronizationHub, ISynchronizationHub> hub)
        {
            _synchronizationHub = hub;
        }

        public async Task SendMoveSynchronization(TransformationViewModel transformation)
        {
            await _synchronizationHub.Clients.All.SendMoveSynchronization(new Vector3((float)transformation.ActionType.XPos, (float)transformation.ActionType.YPos, (float)transformation.ActionType.ZPos), transformation.ActionType.ObjectName);
        }
        public async Task SendRotationSynchronization(TransformationViewModel transformation)
        {
            await _synchronizationHub.Clients.All.SendRotationSynchronization((double)transformation.ActionType.Degrees, transformation.ActionType.ObjectName);
        }
    }
}
