using LogHandler.Microservice.Context;
using LogHandler.Microservice.Model;
using Microsoft.AspNetCore.Mvc;

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

        public LogModel GetLogByUserId(string userid)
        {
            return db.Log.Where(x => x.userId == userid).FirstOrDefault();
        }
    }
}
