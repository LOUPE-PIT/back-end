using ObjectHandler.Microservice.Model;

namespace ObjectHandler.Microservice.Data
{
    public interface IObjectDAL
    {
        List<ObjectModel> GetAllObjects();
        ObjectModel GetObjectByClassId(string classId);
        ObjectModel UploadObject(ObjectModel objectModel);
    }
}
