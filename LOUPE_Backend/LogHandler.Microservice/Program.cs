using LogHandler.Microservice.Context;
using LogHandler.Microservice.Data;
using LogHandler.Microservice.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<ILogDAL, LogDAL>();
builder.Services.AddDbContext<LogDbContext>(x => x.UseSqlServer(connectionString));


var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

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
