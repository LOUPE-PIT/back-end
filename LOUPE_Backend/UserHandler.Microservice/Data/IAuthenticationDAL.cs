using Microsoft.AspNetCore.Mvc;
using Authentication.Microservice.Model;

namespace Authentication.Microservice.Data
{
    public interface IAuthenticationDAL
    {
        ActionResult AddUser(UserModel user);
        List<UserModel> GetUsers();
        UserModel UpdateUser(UserModel user);
        UserModel GetUserById(Guid id);
        public ActionResult DeleteUserById(Guid id);
    }
}