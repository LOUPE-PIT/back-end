using LogHandler.Microservice.Model;
using Microsoft.AspNetCore.Mvc;

namespace LogHandler.Microservice.Data
{
    public interface ILogDAL
    {
        ActionResult InsertLog(LogModel log);
        List<LogModel> GetAllLogs();
        LogModel GetLogByLogId(int id);
        LogModel GetLogByUserId(int userid);
    }
}
