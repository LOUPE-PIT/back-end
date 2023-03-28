namespace GroupingService.Core.Api.Services.RoomCodeService;

public interface IRoomCodeService
{
    Task<string> GenerateRoomCode();
}