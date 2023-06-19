using System.Collections.ObjectModel;
using LogService.DataAccessLayer.Models;

namespace LogService.DataAccessLayer.Repositories;

public interface ILogRepository
{
    Task<Collection<Log>> GetAll();
    Task<Collection<Log?>> ByGroupId(Guid groupId);
    Task New(Log log);
    Task Update(Log log);
    Task Delete(Log log);
}