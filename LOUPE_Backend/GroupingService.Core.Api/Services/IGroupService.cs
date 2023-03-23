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
}