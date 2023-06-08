using Microsoft.AspNetCore.Mvc;
using UserService.DataLayer.Models.User;

namespace UserService.Core.API.Services
{
    public interface IUserService
    {
        Task AddUser(UserModel user);
        Task<ICollection<UserModel>> GetUsers();
        Task UpdateUser(UserModel user);
        Task<UserModel> GetUserById(Guid id, CancellationToken cancellationToken);
        Task DeleteUserById(Guid id);
    }
}
