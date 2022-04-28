using LogHandler.Microservice.Context;
using LogHandler.Microservice.Model;

namespace LogHandler.Microservice.Data
{
    public class DataSeeder
    {
        private readonly LogDbContext logDbContext;

        public DataSeeder(LogDbContext logDbContext)
        {
            this.logDbContext = logDbContext;
        }

        public void Seed()
        {
            if (!logDbContext.Log.Any())
            {
                var logs = new List<LogModel>()
                {
                    new LogModel()
                    {
                        logId = "1",
                        userId = "55",
                        log = "This is a test log entry"
                    },
                    new LogModel()
                    {
                        logId = "2",
                        userId = "44",
                        log = "This is the second test log entry"
                    }
                };

                logDbContext.Log.AddRange(logs);
                logDbContext.SaveChanges();
            }
        }

    }
}
