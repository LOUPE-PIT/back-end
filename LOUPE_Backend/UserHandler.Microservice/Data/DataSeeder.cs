using User.Microservice.Context;
using User.Microservice.Model;

namespace User.Microservice.Data
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
                        userID = "44",
                        name = "Sem"
                    },
                    new UserModel()
                    {
                        userID = "55",
                        name = "Nahir"
                    }
                };

                userDbContext.User.AddRange(user);
                userDbContext.SaveChanges();
            }
        }

    }
}
