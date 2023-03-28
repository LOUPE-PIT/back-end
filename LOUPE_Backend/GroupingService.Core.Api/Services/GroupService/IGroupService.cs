using System.Collections.ObjectModel;
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
    Task<Group?> ByRoomCode(string roomCode);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomCode"></param>
    /// <param name="groupRequestBody"></param>
    void New(string roomCode, GroupRequestBody groupRequestBody);
}