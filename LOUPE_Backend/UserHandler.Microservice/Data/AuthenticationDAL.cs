using Microsoft.AspNetCore.Mvc;
using Authentication.Microservice.Context;
using Authentication.Microservice.Model;

namespace Authentication.Microservice.Data
{
    public class AuthenticationDAL : IAuthenticationDAL
    {
        private readonly UserDbContext db;

        public AuthenticationDAL(UserDbContext db)
        {
            this.db = db;
        }

        public List<UserModel> GetUsers() => db.User.ToList();

        public UserModel UpdateUser(UserModel user)
        {
            db.User.Update(user);
            db.SaveChanges();
            return db.User.Where(x => x.userId == user.userId).FirstOrDefault();
        }

        public ActionResult AddUser(UserModel user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return new OkResult();
        }

        public UserModel GetUserById(Guid id)
        {
            return db.User.Where(x => x.userId == id).FirstOrDefault();
        }

        public ActionResult DeleteUserById(Guid id)
        {
            db.User.Remove(db.User.Where(x => x.userId == id).FirstOrDefault());
            db.SaveChanges();
            return new OkResult();
        }
    }
}
