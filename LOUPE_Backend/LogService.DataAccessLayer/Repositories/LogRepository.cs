using System.Collections.ObjectModel;
using LogService.DataAccessLayer.Context;
using LogService.DataAccessLayer.Models;

namespace LogService.DataAccessLayer.Repositories;

public class LogRepository : ILogRepository
{
    //Context
    private readonly LogDbContext _logDbContext;

    public LogRepository(LogDbContext logDbContext)
    {
        _logDbContext = logDbContext;
    }

    public Task<Collection<Log>> GetAll()
    {
        return Task.FromResult(new Collection<Log>(_logDbContext.Logs.ToList()));
    }
}