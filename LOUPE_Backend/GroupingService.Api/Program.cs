using System.Text.Json.Serialization;
using GroupingService.Core.Api.Services.GroupService;
using GroupingService.Core.Api.Services.GroupService.Implementation;
using GroupingService.Core.Api.Services.RoomCodeService;
using GroupingService.Core.Api.Services.RoomCodeService.Implementation;
using GroupingService.DataAccessLayer.Context;
using GroupingService.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");

//SERVICES
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<IGroupRepository, GroupRepository>();
builder.Services.AddTransient<IRoomCodeService, RoomCodeService>();

builder.Services.AddDbContext<GroupDbContext>(x => x.UseSqlServer(connectionString!));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddOpenTelemetryTracing(builder =>
{
    builder
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("GroupingService"))
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
    var y = scope.ServiceProvider.GetRequiredService<GroupDbContext>();
    y.Database.Migrate();
}

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