using Microsoft.AspNetCore.Mvc;
using ObjectHandler.Microservice.Context;
using ObjectHandler.Microservice.Model;

namespace ObjectHandler.Microservice.Data
{
    public class ObjectDAL : IObjectDAL
    {
        private readonly ObjectDbContext db;

        public ObjectDAL(ObjectDbContext db)
        {
            this.db = db;
        }

        public List<ObjectModel> GetAllObjects() => db.Object.ToList();

        public ObjectModel GetObjectByClassId(int classId)
        {
            return db.Object.Where(x => x.Id == classId).FirstOrDefault();
        }


        public ActionResult UploadObject(ObjectModel objectModel)
        {
            db.Object.Add(objectModel);
            db.SaveChanges();
            return new OkResult();
        }
    }
}
