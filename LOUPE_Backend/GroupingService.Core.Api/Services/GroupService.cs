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
    
    // </ inheritdoc>
    public async Task<Collection<Group>> GetAll()
    {
        var groups = await _groupingRespository.GetAll();
        return groups;
    }
}