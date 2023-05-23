using System.Collections.ObjectModel;
using System.Net;
using GroupingService.Core.Api.Services.GroupService.Contracts;
using GroupingService.Core.Api.Services.RoomCodeService;
using GroupingService.Core.Api.ViewModels;
using GroupingService.DataAccessLayer.Context;
using GroupingService.DataAccessLayer.Models;
using GroupingService.DataAccessLayer.Repositories;
using Refit;

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
    public async Task<Collection<Group>> ByRoomCode(string roomCode)
    {
        return await _groupingRespository.GetAllByRoomCode(roomCode);
    }

    /// <inheritdoc/>
    public async Task<GroupActionResponse> NewAsync(GroupRequestBody groupRequestBody,
        CancellationToken cancellationToken)
    {
        var response = new GroupActionResponse();
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
        response.ResultString = Enum.GetName(typeof(ActionResult), ActionResult.Succesvol);
        return await Task.FromResult(response);
    }

    // <inheritdoc />
    public async Task<GroupActionResponse> DeleteAsync(string roomCode, CancellationToken cancellationToken)
    {
        var response = new GroupActionResponse();
        var groups = await _groupingRespository.GetAllByRoomCode(roomCode);

        foreach (var group in groups)
        {
            await _groupingRespository.ArchiveAsync(group, cancellationToken);
        }
        
        response.Result = ActionResult.Succesvol;
        return response;
    }
}