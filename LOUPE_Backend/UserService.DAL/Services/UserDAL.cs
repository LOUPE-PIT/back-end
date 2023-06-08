using Microsoft.AspNetCore.Mvc;
using UserService.DataLayer.Models.User;
using UserService.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace UserService.DataLayer.Services
{
    public class UserDAL : IUserDAL
    {
        private readonly UserDbContext db;

        public UserDAL(UserDbContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<UserModel>> GetUsers() => db.User_Db.ToList();

        public Task UpdateUser(UserModel user)
        {
            db.User_Db.Update(user);
            db.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task AddUser(UserModel user)
        {
            await db.User_Db.AddAsync(user);
            db.SaveChanges();
        }

        public async Task<UserModel> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            return await db.User_Db.AsNoTracking().FirstOrDefaultAsync(u => u.userId == id, cancellationToken);
        }

        public Task DeleteUserById(Guid id)
        {
            db.User_Db.Remove(db.User_Db.Where(x => x.userId == id).FirstOrDefault());
            db.SaveChanges();
            return Task.CompletedTask;
        }

    }
}
