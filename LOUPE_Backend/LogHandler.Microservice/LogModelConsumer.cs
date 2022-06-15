
using MassTransit;
using SharedLibrary;

namespace LogHandler.Microservice
{

    public class LogModelConsumer : IConsumer<LogModel>
    {
        private ILogger<LogModelConsumer> _logger;

        public LogModelConsumer(ILogger<LogModelConsumer> logger)
        {
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<LogModel> context)
        {
            // Log message in console
            _logger.LogInformation($"Got a new log {context.Message.log}");
        }
    }
}
