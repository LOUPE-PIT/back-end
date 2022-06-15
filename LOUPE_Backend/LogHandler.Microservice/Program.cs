using LogHandler.Microservice;
using LogHandler.Microservice.Context;
using LogHandler.Microservice.Data;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary;

RabbitMQSettings rMQSettings = new RabbitMQSettings();

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<ILogDAL, LogDAL>();
builder.Services.AddDbContext<LogDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
    // This microservice is the receiver from the message.
    // Add Consumer which reads the sent message;
    config.AddConsumer<LogModelConsumer>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        // Connect to RabbitMQ server;
        cfg.Host("amqp://" + rMQSettings.Username + ":" + rMQSettings.Password + "@" + rMQSettings.IPAddress);
        // Add endpoint which will recieve messages from the [model] queue, these messages will be returned in via Consumer class;
        // In here you will be able to change settings, like setting the queue messageretry interval and more;
        cfg.ReceiveEndpoint(rMQSettings.QueueName, c =>
        {
            c.ConfigureConsumer<LogModelConsumer>(ctx);
        });
    });
});
builder.Services.AddMassTransitHostedService();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(Microsoft.Extensions.Hosting.IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

// Automatically Migrate the database
//using (var scope = app.Services.CreateScope())
//{
//    var y = scope.ServiceProvider.GetRequiredService<LogDbContext>();
//    y.Database.Migrate();
//}


// Use swagger
app.UseSwagger();
app.UseSwaggerUI();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapPost("/log/insert", ([FromServices] ILogDAL db, LogModel log) =>
{
    db.InsertLog(log);
});

app.MapGet("/log/all", ([FromServices] ILogDAL db) =>
{
    return db.GetAllLogs();
});

app.MapGet("/log/{id}", ([FromServices] ILogDAL db, int id) =>
{
    return db.GetLogByLogId(id);
});

app.MapGet("/log/user/{id}", ([FromServices] ILogDAL db, int id) =>
{
    return db.GetLogByUserId(id);
});

app.Run();

public partial class LogProgram { }
