using Authentication.Microservice.Context;
using Authentication.Microservice.Model;

namespace Authentication.Microservice.Data
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
            if (!userDbContext.User.Any())
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

                userDbContext.User.AddRange(user);
                userDbContext.SaveChanges();
            }
        }

    }
}
