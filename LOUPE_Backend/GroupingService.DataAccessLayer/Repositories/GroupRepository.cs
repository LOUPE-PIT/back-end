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

    public Task<Group?> ById(string roomCode)
    {
        return Task.FromResult(_groupDbContext.Groups.FirstOrDefault(x => x.RoomCode == roomCode));
    }

    public void New(Group group)
    {
        _groupDbContext.Groups.Add(group);
        _groupDbContext.SaveChangesAsync();
    }
}