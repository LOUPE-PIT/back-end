using Microsoft.AspNetCore.Mvc;
using ObjectHandler.Microservice.Model;

namespace ObjectHandler.Microservice.Data
{
    public interface IObjectDAL
    {
        List<ObjectModel> GetAllObjects();
        ObjectModel GetObjectByClassId(int classId);
        ActionResult UploadObject(ObjectModel objectModel);
    }
}
