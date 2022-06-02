using Microsoft.AspNetCore.Mvc;
using ObjectHandler.Microservice.Data;
using ObjectHandler.Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectHandler.Microservice.Test.Stubs
{
    internal class ObjectDALStub : IObjectDAL
    {
        public bool? testValue = null;
        public List<ObjectModel> GetAllObjects()
        {
            if (testValue == true)
            {
                return new List<ObjectModel>();
            }
            else
            {
                return null;
            }
        }

        public ObjectModel GetObjectByGuid(Guid objectId)
        {
            if (testValue == true)
            {
                return new ObjectModel();
            }
            else
            {
                return null;
            }
        }

        public ActionResult UploadObject(ObjectModel objectModel)
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

        public ActionResult DeleteObjectByGuid(Guid id)
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
    }
}
