using FeedbackService.Api.Core.Profiels;
using FeedbackService.Api.Core.Services;
using FeedbackService.DAL.Context;
using FeedbackService.DAL.Models;
using FeedbackService.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDb");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FeedbackDbContext>(x => x.UseSqlServer());
builder.Services.AddTransient<IFeedbackService, FeedbackServiceCore>();
builder.Services.AddTransient<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddAutoMapper(typeof(FeedbackProfile));

builder.Services.AddOpenTelemetryTracing(builder =>
{
    builder
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("FeedbackService"))
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation(
            options => options.Enrich = (activity, eventName, rawObject) =>
            {
                if (eventName == "api/Feedback/All" && rawObject is System.Net.Http.HttpRequestMessage request && request.Method == HttpMethod.Get)
                {
                    activity.SetTag("Added message", "Manuelly");
                }
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

using(IServiceScope? scope = app.Services.CreateScope())
{
    FeedbackDbContext feedbackDbContext = scope.ServiceProvider.GetRequiredService<FeedbackDbContext>();
    feedbackDbContext.Database.Migrate();
}

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
