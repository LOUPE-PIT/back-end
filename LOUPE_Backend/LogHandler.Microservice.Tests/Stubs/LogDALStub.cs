using LogHandler.Microservice.Data;
using LogHandler.Microservice.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LogHandler.Microservice.Tests.Stubs
{
    internal class LogDALStub : ILogDAL
    {
        public bool? testValue = null;

        public ActionResult InsertLog(LogModel log)
        {
            if (testValue == true)
            {
                return new OkResult();
            }
            else
            {
                return new NotFoundResult();
            }
        }

        public List<LogModel> GetAllLogs()
        {
            if (testValue == true)
            {
                return new List<LogModel>();
            }
            else
            {
                return null;
            }
        }

        public LogModel GetLogByLogId(string id)
        {
            return new LogModel();
        }

        public LogModel GetLogByUserId(string userid)
        {
            return new LogModel();
        }


        List<LogModel> ILogDAL.GetAllLogs()
        {
            throw new System.NotImplementedException();
        }

        LogModel ILogDAL.GetLogByLogId(int id)
        {
            throw new System.NotImplementedException();
        }

        LogModel ILogDAL.GetLogByUserId(int userid)
        {
            throw new System.NotImplementedException();
        }
    }
}
