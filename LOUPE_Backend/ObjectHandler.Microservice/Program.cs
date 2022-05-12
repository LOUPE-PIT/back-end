using Microsoft.AspNetCore.Mvc;
using ObjectHandler.Microservice.Data;
using ObjectHandler.Microservice.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IObjectDAL, ObjectDAL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//TODO pull dev-general

/*
 app.MapGet("/user/login/{id}", ([FromServices] IUserDAL db, string id) =>
{
    return db.GetUserById(id);
});
*/

// Get all objects
app.MapGet("/object/all", ([FromServices] IObjectDAL db) =>
{
    return db.GetAllObjects();
});

// Get all objects
app.MapGet("/object/byclass/{classid}", ([FromServices] IObjectDAL db, string classid) =>
{
    return db.GetObjectByClassId(classid);
});

// Get all objects
app.MapPost("/object/upload", ([FromServices] IObjectDAL db, ObjectModel objectModel) =>
{
    return db.UploadObject(objectModel);
});


app.Run();
