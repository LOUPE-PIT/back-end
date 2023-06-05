using System.Text.Json.Serialization;
using LogService.Api.LogServer;
using LogService.Core.Api.Services;
using LogService.DataAccessLayer.Context;
using LogService.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
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

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        });
});

builder.Services.AddOpenTelemetryTracing(builder =>
{
    builder
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("LogService"))
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation(
            options => options.Enrich = (activity, eventName, rawObject) =>
            {

            }

        )
        .AddGrpcClientInstrumentation(options => options.SuppressDownstreamInstrumentation = true)
        .AddEntityFrameworkCoreInstrumentation(options => options.SetDbStatementForText = true)
        .AddZipkinExporter(options =>
        {

        })
        .AddJaegerExporter(options =>
        {

        });
});

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

app.UseRouting();
// Cors
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();