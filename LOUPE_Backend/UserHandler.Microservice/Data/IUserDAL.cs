using Microsoft.AspNetCore.Mvc;
using User.Microservice.Model;

namespace User.Microservice.Data
{
    public interface IUserDAL
    {
        ActionResult AddUser(UserModel user);
        List<UserModel> GetUsers();
        UserModel UpdateUser(UserModel user);
        UserModel GetUserById(string id);
        public ActionResult DeleteUserById(string id);
    }
}