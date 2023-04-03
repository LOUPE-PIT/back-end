using GroupingService.DataAccessLayer.Repositories;

namespace GroupingService.Core.Api.Services.RoomCodeService.Implementation;

public class RoomCodeService : IRoomCodeService
{
    private readonly IGroupRepository _repository;

    public RoomCodeService(IGroupRepository repository)
    {
        _repository = repository;
    }

    public Task<string> GenerateUniqueRoomCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var newRoomCode = new string(
            Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        
        _repository.CheckIfExists(newRoomCode);
        return Task.FromResult(newRoomCode);
    }
}