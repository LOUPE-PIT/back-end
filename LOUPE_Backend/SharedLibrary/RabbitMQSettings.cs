
namespace SharedLibrary
{
    public class RabbitMQSettings
    { 
        // RabbitMQ properties;

        public readonly string Username;
        public readonly string Password;
        // You can put in localhost if you decide to run it locally, otherwise put down the IP address of the server which you're trying to connect to;
        public readonly string IPAddress;
        public readonly string QueueName;


        public RabbitMQSettings()
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                Username = "user";
                Password = "password";
                IPAddress = "192.168.150.130:5672";
                QueueName = "log-queue";

            }
            else
            {
                Username = Environment.GetEnvironmentVariable("rabbitmq:user");
                Password = Environment.GetEnvironmentVariable("rabbitmq:password");
                IPAddress = Environment.GetEnvironmentVariable("rabbitmq:ip-address");
                QueueName = Environment.GetEnvironmentVariable("rabbitmq:queue-name");
            }
        }
    }
}
