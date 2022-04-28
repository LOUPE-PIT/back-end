using LogHandler.Microservice.Model;
using Microsoft.AspNetCore.Mvc;

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
