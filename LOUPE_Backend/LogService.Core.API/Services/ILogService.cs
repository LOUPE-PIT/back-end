using System.Collections.ObjectModel;
using LogService.Core.Api.Contracts;
using LogService.DataAccessLayer.Models;

namespace LogService.Core.Api.Services;

public interface ILogService
{
    Task<Collection<Log>> GetAll();
    Task<Collection<Log>> ByGroupId(Guid groupId);
    Task<LogResponse> New(Log log);
    Task<LogResponse> Update(Log log);
    Task<LogResponse> Delete(Log log);
    Task<LogResponse> SaveSyncLog(Log log);
}