using LogHandler.Microservice;
using LogHandler.Microservice.Context;
using LogHandler.Microservice.Data;
using LogHandler.Microservice.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<ILogDAL, LogDAL>();
builder.Services.AddDbContext<LogDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
    var user = builder.Configuration["rabbitmq:user"];
    var password = builder.Configuration["rabbitmq:password"];
    var ipaddress = builder.Configuration["rabbitmq:ip-address"];
    var queueName = builder.Configuration["rabbitmq:queue-name"];



    // Add Consumer which reads the sent message;
    config.AddConsumer<LogModelConsumer>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        // Connect to RabbitMQ server;
        cfg.Host("amqp://" + user + ":" + password + "@" + ipaddress);
        // Add endpoint which will recieve messages from the [model] queue, these messages will be returned in via Consumer class;
        // In here you will be able to change settings, like setting the queue messageretry interval and more;
        cfg.ReceiveEndpoint(queueName, c =>
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
using (var scope = app.Services.CreateScope())
{
    var y = scope.ServiceProvider.GetRequiredService<LogDbContext>();
    y.Database.Migrate();
}




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.MapGet("/log/{id}", ([FromServices] ILogDAL db, string id) =>
{
    return db.GetLogByLogId(id);
});

app.MapGet("/log/user/{id}", ([FromServices] ILogDAL db, string id) =>
{
    return db.GetLogByUserId(id);
});

app.Run();

public partial class LogProgram { }
