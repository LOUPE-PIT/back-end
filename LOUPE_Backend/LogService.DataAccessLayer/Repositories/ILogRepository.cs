using System.Collections.ObjectModel;
using LogService.DataAccessLayer.Models;

namespace LogService.DataAccessLayer.Repositories;

public interface ILogRepository
{
    Task<Collection<Log>> GetAll();
    Task<Log?> ById(Guid id);
    Task New(Log log);
    Task Update(Log log);
    Task Delete(Log log);
}