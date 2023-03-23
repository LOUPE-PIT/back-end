using System.Collections.ObjectModel;
using GroupingService.DataAccessLayer.Models;

namespace GroupingService.Core.Api.Services;

public interface IGroupService
{
    /// <summary>
    /// Returns a collection of groups
    /// </summary>
    /// <returns> Collection of groups</returns>
    Task<Collection<Group>> GetAll();

    /// <summary>
    /// Gets a group by its id
    /// </summary>
    /// <param name="Id"> The id of the group </param>
    /// <returns> A group that matches the Id</returns>
    Task<Group?> ById(Guid Id);
}