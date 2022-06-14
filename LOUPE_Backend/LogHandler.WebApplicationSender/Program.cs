using MassTransit;
using SharedLibrary;

//PoC for messaging. The sender is supposed to be the frontend. We didn't have a frontend at the time of making the PoC.

RabbitMQSettings rMQSettings = new RabbitMQSettings();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        // Connect to RabbitMQ server;
        cfg.Host("amqp://" + rMQSettings.Username + ":" + rMQSettings.Password + "@" + rMQSettings.IPAddress);
    });
});
builder.Services.AddMassTransitHostedService();

// App:
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
