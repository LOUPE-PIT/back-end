using System.Text.Json.Serialization;
using LogService.Api.LogServer;
using LogService.Core.Api.Services;
using LogService.DataAccessLayer.Context;
using LogService.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LogDb");

//SERVICES
builder.Services.AddTransient<ILogService, LogService.Core.Api.Services.LogService>();
builder.Services.AddScoped<ILogRepository, LogRepository>();

builder.Services.AddDbContext<LogDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddGrpc();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var y = scope.ServiceProvider.GetRequiredService<LogDbContext>();
    y.Database.Migrate();
}

app.MapGrpcService<LogServer>();

app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Cors
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.Run();