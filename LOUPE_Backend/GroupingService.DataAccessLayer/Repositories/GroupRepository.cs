using System.Collections.ObjectModel;
using GroupingService.DataAccessLayer.Context;
using GroupingService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupingService.DataAccessLayer.Repositories;

public class GroupRepository : IGroupRepository
{
    //Context
    private readonly GroupDbContext _groupDbContext;

    public GroupRepository(GroupDbContext groupDbContext)
    {
        _groupDbContext = groupDbContext;
    }

    public Task<Collection<Group>> GetAll()
    {
        return Task.FromResult(new Collection<Group>(_groupDbContext.Groups.ToList()));
    }

    public Task<Collection<Guid>> GetParticipants()
    {
        throw new NotImplementedException();
    }


    public Task<Collection<Group>> GetAllByRoomCode(string roomCode)
    {
        return Task.FromResult(new Collection<Group>(_groupDbContext.Groups.Where(x => x.RoomCode == roomCode).ToList()));
    }

    public Task<Group?> ByRoomCode(string roomCode)
    {
        return Task.FromResult(_groupDbContext.Groups.FirstOrDefault(x => x.RoomCode == roomCode));
    }

    public async Task NewAsync(Group group, GroupDbContext dbContext, CancellationToken cancellationToken)
    {
        await dbContext.Groups.AddAsync(group, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task ArchiveAsync(Group group, CancellationToken cancellationToken)
    {
        var groupToBeArchived = new ArchivedGroup
        {
            Id = group.Id,
            RoomCode = group.RoomCode,
            UserId = group.UserId
        };
        
        _groupDbContext.Groups.Remove(group);
        await _groupDbContext.SaveChangesAsync(cancellationToken);
    
        await _groupDbContext.ArchivedGroups.AddAsync(groupToBeArchived, cancellationToken);
        await _groupDbContext.SaveChangesAsync(cancellationToken);
    }

    public bool CheckIfExists(string roomCode)
    {
        return _groupDbContext.Groups.Any(g => g.RoomCode == roomCode);
    }
}