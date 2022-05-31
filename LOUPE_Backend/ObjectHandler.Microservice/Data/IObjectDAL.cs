using Microsoft.AspNetCore.Mvc;
using ObjectHandler.Microservice.Model;

namespace ObjectHandler.Microservice.Data
{
    public interface IObjectDAL
    {
        List<ObjectModel> GetAllObjects();
        //ObjectModel GetObjectByClassId(int classId);
        ObjectModel GetObjectByGuid(Guid objectId);
        ActionResult UploadObject(ObjectModel objectModel);
        ActionResult DeleteObjectByGuid(Guid id);
    }
}
