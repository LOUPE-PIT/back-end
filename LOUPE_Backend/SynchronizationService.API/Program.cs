using SynchronizationService.API.Extension_Methods;
using SynchronizationService.API.Hubs;
using SynchronizationService.Core.API.Profiles;
using SynchronizationService.DataLayer.Models.MongoDB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMongoDB(builder.Configuration.GetSection(nameof(TransformationsDatabaseSettings)), builder.Configuration.GetSection("TransformationsDatabaseSettings:Connectionstring").Value);

builder.Services.AddServices();

builder.Services.AddStrategies();

builder.Services.AddAutoMapper(typeof(ActionProfile), typeof(TransformationProfile));

builder.Services.AddGrpc();
builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials());

app.MapControllers();
app.MapHub<SynchronizationHub>("/hubs/sync");

app.Run();
