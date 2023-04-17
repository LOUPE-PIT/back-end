using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SynchronizationService.API.SyncLogService;
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

builder.Services.Configure<TransformationsDatabaseSettings>(builder.Configuration.GetSection(nameof(TransformationsDatabaseSettings)));
builder.Services.AddSingleton<ITransformationsDatabaseSettings>(sp => sp.GetRequiredService<IOptions<TransformationsDatabaseSettings>>().Value);
Console.WriteLine(builder.Configuration.GetValue<string>("TransformationsDatabaseSettings:Connectionstring"));
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("TransformationsDatabaseSettings:Connectionstring")));

builder.Services.AddTransient<ISynchronizationService, SyncService>();
builder.Services.AddTransient<SyncLogService>();

builder.Services.AddTransient<RotationActionStrategy>();
builder.Services.AddTransient<TranslationActionStrategy>();
builder.Services.AddTransient<PressActionStrategy>();

builder.Services.AddTransient<IActionStrategy>(provider =>
    new NamedStrategyProvider("Rotate", provider.GetService<RotationActionStrategy>()!));
builder.Services.AddTransient<IActionStrategy>(provider =>
    new NamedStrategyProvider("Translate", provider.GetService<TranslationActionStrategy>()!));
builder.Services.AddTransient<IActionStrategy>(provider =>
    new NamedStrategyProvider("Press", provider.GetService<PressActionStrategy>()!));

builder.Services.AddScoped<ITransformationRepository, TransformationRepository>();

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
