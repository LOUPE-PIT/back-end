using Microsoft.AspNetCore.SignalR;
using System.Numerics;

namespace SynchronizationService.API.Hub
{
    public interface ISynchronizationHub
    {
        Task SendMoveSynchronization(Vector3 newPos, string objectName);
        Task SendRotationSynchronization(double newRotation, string objectName);
    }
}
