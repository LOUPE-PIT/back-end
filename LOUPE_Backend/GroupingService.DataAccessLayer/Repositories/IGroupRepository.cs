using System.Collections.ObjectModel;
using GroupingService.DataAccessLayer.Models;

namespace GroupingService.DataAccessLayer.Repositories;

public interface IGroupRepository
{
    Task<Collection<Group>> GetAll();
    Task<Group?> ById(string roomCode);
    void New(Group group);
}