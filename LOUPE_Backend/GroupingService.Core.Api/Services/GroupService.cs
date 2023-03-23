using System.Collections.ObjectModel;
using GroupingService.DataAccessLayer.Models;
using GroupingService.DataAccessLayer.Repositories;

namespace GroupingService.Core.Api.Services;

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
    public async Task<Group?> ById(Guid Id)
    {
        return await _groupingRespository.ById(Id);
    }
}