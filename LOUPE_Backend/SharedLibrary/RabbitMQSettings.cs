
namespace SharedLibrary
{
    public class RabbitMQSettings
    { 
        // RabbitMQ properties;

        public readonly string Username = "guest";
        public readonly string Password = "guest";
        // You can put in localhost if you decide to run it locally, otherwise put down the IP address of the server which you're trying to connect to;
        public readonly string IPAddress = "192.168.15.128:5672";
        public readonly string QueueName = "log-queue";
    }
}
