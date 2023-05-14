using System.Collections.ObjectModel;
using GroupingService.DataAccessLayer.Context;
using GroupingService.DataAccessLayer.Models;

namespace GroupingService.DataAccessLayer.Repositories;

public interface IGroupRepository
{
    Task<Collection<Group>> GetAll();
    Task<Collection<Guid>> GetParticipants();
    Task<Collection<Group>> GetAllByRoomCode(string roomCode);
    Task NewAsync(Group group, GroupDbContext dbContext, CancellationToken cancellationToken);
    Task ArchiveAsync(Group group, CancellationToken cancellationToken);
    bool CheckIfExists(string roomCode);
}