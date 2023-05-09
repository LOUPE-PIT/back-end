using SynchronizationService.API.Extension_Methods;
using SynchronizationService.Core.API.Profiles;
using SynchronizationService.DataLayer.Models.MongoDB;

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

builder.Services.AddGrpc();

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
