using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace LogHandler.Microservice.Data
{
    public interface ILogDAL
    {
        ActionResult InsertLog(LogModel log);
        List<LogModel> GetAllLogs();
        LogModel GetLogByLogId(string id);
        LogModel GetLogByUserId(string userid);
    }
}
