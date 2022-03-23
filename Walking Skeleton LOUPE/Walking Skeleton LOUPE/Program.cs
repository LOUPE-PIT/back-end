using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Walking_Skeleton_LOUPE.Model;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionstring));


var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using(var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", (Func<string>)(() => "Hello World!"));

app.MapGet("/user", (Func<User>)(() =>
{
    return new User()
    {
        Name = "Youssef",
        Citizenship = "Turks",
        UserId = "1"
    };
}));

app.MapGet("/users", ([FromServices] UserDbContext db) =>
   {
       return db.User.ToList();
   }
);

//app.MapGet("/users/{id}", async (http) =>
//{
//    if(!http.Request.RouteValues.TryGetValue("id", out var id))
//    {
//        http.Response.StatusCode = 400;
//    }
//    else
//    {
//        await http.Response.WriteAsJsonAsync(new EmployeeCollection().GetEmployees().FirstOrDefault(x => x.EmployeeId == (string)id));
//    }
//});

app.Run();
