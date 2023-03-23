using System.Collections.ObjectModel;
using LogService.DataAccessLayer.Models;

namespace LogService.DataAccessLayer.Repositories;

public interface ILogRepository
{
    Task<Collection<Log>> GetAll();
}