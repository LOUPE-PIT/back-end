using System.Collections.ObjectModel;
using LogService.DataAccessLayer.Models;

namespace LogService.Core.Api.Services;

public interface ILogService
{
    Task<Collection<Log>> GetAll();
}