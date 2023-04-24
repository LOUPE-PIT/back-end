using AuthenticationService.DataLayer.Context;
using AuthenticationService.DataLayer.Models.User;

namespace AuthenticationService.DataLayer.Services
{
    // dataseeder to seed the database with data. not needed can manually add data as well.
    public class DataSeeder
    {
        private readonly UserDbContext userDbContext;

        public DataSeeder(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public void Seed()
        {
            if (!userDbContext.User_Db.Any())
            {
                var user = new List<UserModel>()
                {
                    new UserModel()
                    {
                        userId = new Guid(),
                        name = "Sem"
                    },
                    new UserModel()
                    {
                        userId = new Guid(),
                        name = "Nahir"
                    }
                };

                userDbContext.User_Db.AddRange(user);
                userDbContext.SaveChanges();
            }
        }

    }
}
