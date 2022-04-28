using ObjectHandler.Microservice.Model;

namespace ObjectHandler.Microservice.Data
{
    public class ObjectDAL : IObjectDAL
    {
        public List<ObjectModel> GetAllObjects()
        {
            return new List<ObjectModel>()
            {
                new ObjectModel()
                {
                    Id = "0",
                    Location = "/Root/ObjectRepository/testobject_0000.obj"
                },
                new ObjectModel()
                {
                    Id = "1",
                    Location = "/Root/ObjectRepository/testobject_0001.obj"
                }
            };
        }

        public ObjectModel UploadObject(ObjectModel objectModel)
        {
            //TODO
            return objectModel;
        }

        public ObjectModel GetObjectByClassId(string classId)
        {
            return new ObjectModel()
            {
                Id = "0",
                Location = "/Root/ObjectRepository/testobject_0000.obj"
            };
        }
    }
}
