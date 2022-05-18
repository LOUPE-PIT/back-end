using LogHandler.Microservice.Context;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace LogHandler.Microservice.Data
{
    public class LogDAL : ILogDAL
    {
        private readonly LogDbContext db;

        public LogDAL(LogDbContext db)
        {
            this.db = db;
        }

        public ActionResult InsertLog(LogModel log)
        {
            db.Log.Add(log);
            db.SaveChanges();
            return new OkResult();
        }

        public List<LogModel> GetAllLogs() => db.Log.ToList();

        public LogModel GetLogByLogId(string id)
        {
            return db.Log.Where(x => x.logId == id).FirstOrDefault();
        }

        public LogModel GetLogByUserId(string id)
        {
            return db.Log.Where(x => x.userId == id).FirstOrDefault();
        }
    }
}
