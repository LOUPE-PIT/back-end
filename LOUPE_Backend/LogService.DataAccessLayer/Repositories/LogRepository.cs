using System.Collections.ObjectModel;
using LogService.DataAccessLayer.Context;
using LogService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

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

    public Task<Log?> ById(Guid id)
    {
        return Task.FromResult(_logDbContext.Logs.FirstOrDefault(l => l.Id == id));
    }

    public async Task New(Log log)
    {
        await _logDbContext.Logs.AddAsync(log);
        await _logDbContext.SaveChangesAsync();
    }

    public async Task Update(Log log)
    {
        _logDbContext.Update(log);
        await _logDbContext.SaveChangesAsync();
    }

    public async Task Delete(Log log)
    {
        _logDbContext.Remove(log);
        await _logDbContext.SaveChangesAsync();
    }
}