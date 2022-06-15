using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

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
