using System.Collections.ObjectModel;
using GroupingService.DataAccessLayer.Models;

namespace GroupingService.DataAccessLayer.Repositories;

public interface IGroupRepository
{
    Task<Collection<Group>> GetAll();
}