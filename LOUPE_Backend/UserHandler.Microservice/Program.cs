using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User.Microservice.Context;
using User.Microservice.Data;
using User.Microservice.Model;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

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
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.MapGet("/user/login/{id}", ([FromServices] IUserDAL db, int id) =>
{
    return db.GetUserById(id);
});

app.MapDelete("/user/delete/{id}", ([FromServices] IUserDAL db, int id) =>
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