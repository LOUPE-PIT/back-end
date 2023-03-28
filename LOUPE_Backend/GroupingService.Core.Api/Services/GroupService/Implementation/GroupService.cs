using System.Collections.ObjectModel;
using GroupingService.Core.Api.ViewModels;
using GroupingService.DataAccessLayer.Models;
using GroupingService.DataAccessLayer.Repositories;

namespace GroupingService.Core.Api.Services.GroupService.Implementation;

public class GroupService : IGroupService
{
    //Repository
    private readonly IGroupRepository _groupingRespository;

    public GroupService(IGroupRepository groupingRespository)
    {
        _groupingRespository = groupingRespository;
    }

    /// <inheritdoc/>
    public async Task<Collection<Group>> GetAll()
    {
        return await _groupingRespository.GetAll();
    }

    /// <inheritdoc/>
    public async Task<Group?> ByRoomCode(string roomCode)
    {
        return await _groupingRespository.ById(roomCode);
    }

    /// <inheritdoc/>
    public void New(string roomCode, GroupRequestBody groupRequestBody)
    {
        foreach (var userId in groupRequestBody.UserIds)
        {
            var groupEntry = new Group
            {
                RoomCode = roomCode,
                UserId = userId
            };
            _groupingRespository.New(groupEntry);
        }
    }
}