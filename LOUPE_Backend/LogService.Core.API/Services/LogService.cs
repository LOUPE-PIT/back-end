using System.Collections.ObjectModel;
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
}