using Microsoft.AspNetCore.SignalR;
using SynchronizationService.API.Hubs.Messages;

namespace SynchronizationService.API.Hubs
{
    public class SynchronizationHub : Hub
    {
        public async Task JoinRoom(Guid roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());

            Console.WriteLine($"{Context.ConnectionId} connected to room: {roomId}");
        }

        public async Task ReceiveSynchronization(SynchronizationMessage message, Guid roomId)
        {
            await Clients.Group(roomId.ToString()).SendAsync("ReceiveSynchronization", $"{message.NewPosition.ToString()} {message.DegreesRotation} {message.ObjectName}");
        }
    }
}
