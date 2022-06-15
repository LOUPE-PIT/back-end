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
builder.Services.AddScoped<IFTPObjectDAL, FTPObjectDAL>();
builder.Services.AddDbContext<ObjectDbContext>(x => x.UseSqlServer(connectionString));
//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add swagger
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Automatically Migrate the database
using (var scope = app.Services.CreateScope())
{
    var y = scope.ServiceProvider.GetRequiredService<ObjectDbContext>();
    y.Database.Migrate();
}




// Get all objects
app.MapGet("/objects/getall", ([FromServices] IObjectDAL db) =>
{
    return db.GetAllObjects();
});

// Get objects by classroom id
// API CALL FOR FUTURE DEVELOPMENT WHEN CLASS.MICROSERVICE IS DEVELOPED.
//app.MapGet("/objects/{classid}/get", ([FromServices] IObjectDAL db, int classid) =>
//{
//    return db.GetObjectByClassId(classid);
//});

//Uploads and a file to the FTP service and saves the path do the database
app.MapPost("object/upload", ([FromServices] IObjectDAL db, [FromServices] IFTPObjectDAL ftp, HttpRequest request) =>
{
    string[] data = ftp.UploadObject(request);
    Guid guid = Guid.Parse(data[0]);
    ObjectModel model = new ObjectModel
    {
        id = Guid.Parse(data[0]),
        desciption = data[1]
    };
    return db.UploadObject(model);
});

// Run this api with the objectId you get from /objects/getall
app.MapGet("object/download", ([FromServices] IFTPObjectDAL ftp, string objectId) =>
{
    return ftp.DownloadObject(objectId);
    
});

// a quality of life api call to easily delete objects from the FTP server and database
app.MapDelete("object/delete", ([FromServices] IObjectDAL db, [FromServices] IFTPObjectDAL ftp, string guidString) =>
{
    return db.DeleteObjectByGuid(ftp.DeleteObject(guidString));
});

app.Run();

public partial class Program { }