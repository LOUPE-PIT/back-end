using System.Collections.ObjectModel;
using GroupingService.Core.Api.Services.GroupService.Contracts;
using GroupingService.Core.Api.Services.RoomCodeService;
using GroupingService.Core.Api.ViewModels;
using GroupingService.DataAccessLayer.Context;
using GroupingService.DataAccessLayer.Models;
using GroupingService.DataAccessLayer.Repositories;

namespace GroupingService.Core.Api.Services.GroupService.Implementation;

public class GroupService : IGroupService
{
    //Repository
    private readonly IGroupRepository _groupingRespository;

    //Services
    private readonly IRoomCodeService _roomCodeService;

    public GroupService(IGroupRepository groupingRespository, IRoomCodeService roomCodeService)
    {
        _groupingRespository = groupingRespository;
        _roomCodeService = roomCodeService;
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
    public async Task<NewGroupResponse> NewAsync(GroupRequestBody groupRequestBody,
        CancellationToken cancellationToken)
    {
        var response = new NewGroupResponse();
        var roomCode = await _roomCodeService.GenerateUniqueRoomCode();
        
        foreach (var userId in groupRequestBody.UserIds)
        {
            var groupEntry = new Group
            {
                RoomCode = roomCode,
                UserId = userId
            };
            await _groupingRespository.NewAsync(groupEntry, new GroupDbContext(), cancellationToken);
        }

        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }
}