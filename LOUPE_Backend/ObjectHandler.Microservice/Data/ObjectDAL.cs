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

        //public ObjectModel GetObjectByClassId(int classId)
        //{
        //    return db.Object.Where(x => x.Id == classId).FirstOrDefault();
        //}

        public ObjectModel GetObjectByGuid(Guid objectId)
        {
            return db.Object.Where(x => x.id == objectId).FirstOrDefault();
        }


        public ActionResult UploadObject(ObjectModel objectModel)
        {
            db.Object.Add(objectModel);
            db.SaveChanges();
            return new OkResult();
        }
        public ActionResult DeleteObjectByGuid(Guid id)
        {
            db.Object.Remove(db.Object.Where(x => x.id == id).FirstOrDefault());
            db.SaveChanges();
            return new OkResult();
        }
    }
}
