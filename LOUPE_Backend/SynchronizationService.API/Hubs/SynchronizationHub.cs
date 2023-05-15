using Microsoft.AspNetCore.SignalR;

namespace SynchronizationService.API.Hubs
{
    public class SynchronizationHub : Hub
    {
        public async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);

            Console.WriteLine($"{Context.ConnectionId} connected to room: {roomId}");
        }
        
        public async Task LeaveRoom(string roomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);

            Console.WriteLine($"{Context.ConnectionId} left room: {roomId}");
        }
    }
}
