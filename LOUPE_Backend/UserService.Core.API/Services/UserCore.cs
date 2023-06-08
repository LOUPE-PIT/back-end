using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.DataLayer.Models.User;
using UserService.DataLayer.Services;

namespace UserService.Core.API.Services
{
    public class UserCore : IUserService
    {
        private readonly IUserDAL _userDAL;
        
        public UserCore(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public async Task AddUser(UserModel user)
        {
            await _userDAL.AddUser(user);          
        }

        public Task DeleteUserById(Guid id)
        {
            return _userDAL.DeleteUserById(id);
        }

        public async Task<UserModel> GetUserById(Guid id, CancellationToken cancellationToken)
        {
          return await _userDAL.GetUserById(id, cancellationToken);
        }

        public async Task<ICollection<UserModel>> GetUsers()
        {
            return await _userDAL.GetUsers();
        }

        public async Task UpdateUser(UserModel user)
        {
          await _userDAL.UpdateUser(user);
        }
    }
}
