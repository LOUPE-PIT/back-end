using User.Microservice.Context;
using User.Microservice.Model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace User.Microservice.Data
{
    public class UserDAL : IUserDAL
    {
        private readonly UserDbContext db;

        public UserDAL(UserDbContext db)
        {
            this.db = db;
        }

        public List<UserModel> GetUsers() => db.User.ToList();

        public UserModel UpdateUser(UserModel user)
        {
            db.User.Update(user);
            db.SaveChanges();
            return db.User.Where(x => x.userID == user.userID).FirstOrDefault();
        }

        public ActionResult AddUser(UserModel user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return new OkResult();
        }

        public UserModel GetUserById(string id)
        {
            return db.User.Where(x => x.userID == id).FirstOrDefault();
        }

        public ActionResult DeleteUserById(string id)
        {
            db.User.Remove(db.User.Where(x => x.userID == id).FirstOrDefault());
            db.SaveChanges();
            return new OkResult();
        }
    }
}
