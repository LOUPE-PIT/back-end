using System.Collections.ObjectModel;
using LogService.Core.Api.Contracts;
using LogService.DataAccessLayer.Models;

namespace LogService.Core.Api.Services;

public interface ILogService
{
    Task<Collection<Log>> GetAll();
    Task<Log> ById(Guid id);
    Task<LogResponse> New(Log log);
    Task<LogResponse> Update(Log log);
}