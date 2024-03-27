using System.Collections.ObjectModel;
using GroupingService.Core.Api.Services.GroupService.Contracts;
using GroupingService.Core.Api.ViewModels;
using GroupingService.DataAccessLayer.Models;

namespace GroupingService.Core.Api.Services.GroupService;

public interface IGroupService
{
    /// <summary>
    /// Returns a collection of groups
    /// </summary>
    /// <returns> Collection of groups</returns>
    Task<Collection<Group>> GetAll();

    /// <summary>
    /// Gets a group by its roomCode
    /// </summary>
    /// <param name="roomCode"> The roomCode of the group </param>
    /// <returns> A group that matches the Id</returns>
    Task<Collection<Group>> ByRoomCode(string roomCode);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="groupRequestBody"></param>
    /// <param name="cancellationToken"></param>
    Task<GroupActionResponse> NewAsync(GroupRequestBody groupRequestBody, CancellationToken cancellationToken);

    Task<GroupActionResponse> CreateGroup(CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomCode"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<GroupActionResponse> DeleteAsync(string roomCode, CancellationToken cancellationToken);
}