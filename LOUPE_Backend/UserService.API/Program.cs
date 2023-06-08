using Microsoft.EntityFrameworkCore;
using UserService.Core.API.Services;
using UserService.DataLayer.Context;
using UserService.DataLayer.Models;
using UserService.DataLayer.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDb");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();   
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer());
builder.Services.AddTransient<IUserDAL, UserDAL>();
builder.Services.AddTransient<IUserService, UserCore>();

var app = builder.Build();

using (IServiceScope? scope = app.Services.CreateScope())
{
    UserDbContext UserDbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
    UserDbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
