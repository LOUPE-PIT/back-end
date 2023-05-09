using Microsoft.AspNetCore.SignalR;
using System.Numerics;

namespace SynchronizationService.API.Hub
{
    public class SynchronizationHub : Hub<ISynchronizationHub>
    {
        public async Task SendMoveSynchronization(Vector3 newPos, string objectName)
        {
            await Clients.All.SendMoveSynchronization(newPos, objectName);
        }
        public async Task SendRotationSynchronization(double newRotation, string objectName)
        {
            await Clients.All.SendRotationSynchronization(newRotation, objectName);
        }
    }
}
