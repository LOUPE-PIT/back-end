using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SynchronizationService.API.Extension_Methods;
using SynchronizationService.Core.API.Profiles;
using SynchronizationService.Core.API.Services;
using SynchronizationService.Core.API.Strategies;
using SynchronizationService.Core.API.Strategies.Provider;
using SynchronizationService.DataLayer.Models.MongoDB;
using SynchronizationService.DataLayer.Models.MongoDB.Interfaces;
using SynchronizationService.DataLayer.Services;
using SynchronizationService.DataLayer.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMongoDB(builder.Configuration.GetSection(nameof(TransformationsDatabaseSettings)), builder.Configuration.GetSection("TransformationsDatabaseSettings:Connectionstring").Value);

builder.Services.AddServices();

builder.Services.AddStrategies();

builder.Services.AddAutoMapper(typeof(ActionProfile), typeof(TransformationProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
