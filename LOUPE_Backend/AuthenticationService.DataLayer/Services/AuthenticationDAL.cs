using Microsoft.AspNetCore.Mvc;
using AuthenticationService.DataLayer.Models.User;
using AuthenticationService.DataLayer.Context;

namespace AuthenticationService.DataLayer.Services
{
    public class AuthenticationDAL : IAuthenticationDAL
    {
        private readonly UserDbContext db;

        public AuthenticationDAL(UserDbContext db)
        {
            this.db = db;
        }

        public List<UserModel> GetUsers() => db.User_Db.ToList();

        public UserModel UpdateUser(UserModel user)
        {
            db.User_Db.Update(user);
            db.SaveChanges();
            return db.User_Db.Where(x => x.userId == user.userId).FirstOrDefault();
        }

        public ActionResult AddUser(UserModel user)
        {
            db.User_Db.Add(user);
            db.SaveChanges();
            return new OkResult();
        }

        public UserModel GetUserById(Guid id)
        {
            return db.User_Db.Where(x => x.userId == id).FirstOrDefault();
        }

        public ActionResult DeleteUserById(Guid id)
        {
            db.User_Db.Remove(db.User_Db.Where(x => x.userId == id).FirstOrDefault());
            db.SaveChanges();
            return new OkResult();
        }
    }
}
