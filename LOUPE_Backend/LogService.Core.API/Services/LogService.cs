using System.Collections.ObjectModel;
using LogService.Core.Api.Contracts;
using LogService.DataAccessLayer.Models;
using LogService.DataAccessLayer.Repositories;

namespace LogService.Core.Api.Services;

public class LogService : ILogService
{
    //Repository
    private readonly ILogRepository _logRepository;

    public LogService(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }
    
    // </inheritdoc>
    public async Task<Collection<Log>> GetAll()
    {
        return await _logRepository.GetAll();
    }

    public async Task<Log> ById(Guid id)
    {
        return await _logRepository.ById(id);
    }

    public async Task<LogResponse> New(Log log)
    {
        await _logRepository.New(log);
        var response = new LogResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }

    public async Task<LogResponse> Update(Log log)
    {
        await _logRepository.Update(log);
        var response = new LogResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }

    public async Task<LogResponse> Delete(Log log)
    {
        await _logRepository.Delete(log);
        var response = new LogResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }

    public async Task<LogResponse> SaveSyncLog(Log log)
    {
        await _logRepository.New(log);
        var response = new LogResponse();
        response.Result = ActionResult.Succesvol;
        return await Task.FromResult(response);
    }
}