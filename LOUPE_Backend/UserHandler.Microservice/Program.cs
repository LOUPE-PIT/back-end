using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Context;
using User.Microservice.Data;
using User.Microservice.Model;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
var authenticationProviderKey = "UserKey";

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddAuthentication()
    .AddJwtBearer(authenticationProviderKey, x =>
    {
    });

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

app.MapGet("/user/login/{id}", ([FromServices] IUserDAL db, string id) =>
{
    return db.GetUserById(id);
});

app.MapDelete("/user/delete/{id}", ([FromServices] IUserDAL db, string id) =>
{
    return db.DeleteUserById(id);
});

app.MapGet("/user/all", ([FromServices] IUserDAL db) =>
{
    return db.GetUsers();
});

app.MapPut("/user/update/{id}", ([FromServices] IUserDAL db, UserModel user) =>
{
    db.UpdateUser(user);
});

app.MapPost("/user/add", ([FromServices] IUserDAL db, UserModel user) =>
{
    db.AddUser(user);
});

app.Run();

public partial class Program { }