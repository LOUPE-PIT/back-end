using AuthenticationService.DataLayer.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.DataLayer.Services
{
    public interface IUserDAL
    {
        ActionResult AddUser(UserModel user);
        List<UserModel> GetUsers();
        UserModel UpdateUser(UserModel user);
        UserModel GetUserById(Guid id);
        public ActionResult DeleteUserById(Guid id);
    }
}