using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObjectHandler.Microservice.Context;
using ObjectHandler.Microservice.Data;
using ObjectHandler.Microservice.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("AppDb");
//Add Repository Pattern
builder.Services.AddScoped<IObjectDAL, ObjectDAL>();
builder.Services.AddDbContext<ObjectDbContext>(x => x.UseSqlServer(connectionString));
//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Get all objects
app.MapGet("/object/getall", ([FromServices] IObjectDAL db) =>
{
    return db.GetAllObjects();
});

// Get all objects
app.MapGet("/object/{classid}/get", ([FromServices] IObjectDAL db, int classid) =>
{
    return db.GetObjectByClassId(classid);
});

// Get all objects
//app.MapPost("/object/upload", ([FromServices] IObjectDAL db, ObjectModel objectModel) =>
//{
//    return db.UploadObject(objectModel);
//});

app.MapPost("object/upload", ([FromServices] IObjectDAL db, HttpRequest request) =>
{
    var files = request.Form.Files;
    var dir = Path.Combine(Directory.GetCurrentDirectory(), "Files");
    string fileName = "";

    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
    }


    foreach (var file in files)
    {
        var extension = new FileInfo(file.FileName).Extension;

        fileName = Guid.NewGuid() + extension;

        string fullpath = Path.Combine(dir, fileName);

        using (Stream fs = new FileStream(fullpath, FileMode.OpenOrCreate))
        {
            file.CopyTo(fs);
            fs.Close();
        };
    }

    return db.UploadObject(new ObjectModel()
    {
        Location = "Files/" + fileName
    });
});

app.MapGet("/download", (string id) =>
{
    var dir = Path.Combine(Directory.GetCurrentDirectory(), "Files");

    var file = id + ".png";
    var x = Path.Combine(dir, file);

    return Results.File(x, contentType: "image/png");
});

app.Run();
