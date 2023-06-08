using UserService.DataLayer.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace UserService.DataLayer.Services
{
    public interface IUserDAL
    {
        Task AddUser(UserModel user);
        Task<ICollection<UserModel>> GetUsers();
        Task UpdateUser(UserModel user);
        Task<UserModel> GetUserById(Guid id, CancellationToken cancellationToken);
        Task DeleteUserById(Guid id);
    }
}