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
app.MapGet("/objects/getall", ([FromServices] IObjectDAL db) =>
{
    return db.GetAllObjects();
});

// Get all objects
app.MapGet("/objects/{classid}/get", ([FromServices] IObjectDAL db, int classid) =>
{
    return db.GetObjectByClassId(classid);
});

// Get all objects
//app.MapPost("/object/upload", ([FromServices] IObjectDAL db, ObjectModel objectModel) =>
//{
//    return db.UploadObject(objectModel);
//});

app.MapPost("Objects/upload", (HttpRequest request) =>
{
    // Get all files from the request
    var files = request.Form.Files;

    // For each file, start the upload process
    foreach (var file in files)
    {
        // Get the file extension
        var extension = new FileInfo(file.FileName).Extension;

        // Generate a new file name
        string name = Guid.NewGuid() + extension;

        // Connect to my FTP server
        var client = new FluentFTP.FtpClient("192.168.150.128", "testuser", "root");
        client.AutoConnect();

        // Turn the file into a byte[]
        var ms = new MemoryStream();
        file.CopyTo(ms);
        ms.Close();
        var array = ms.ToArray();

        // Upload the file to FTP
        var x = client.Upload(array, name);

        // Disconnect the client
        client.Disconnect();
    }
});

app.MapGet("objects/download", () =>
{
    // Connect to FTP server
    var client = new FluentFTP.FtpClient("192.168.150.128", "testuser", "root");
    client.AutoConnect();

    // Creating a new memory stream to save the file to
    var ms = new MemoryStream();

    // Download the file to the memory stream
    client.Download(ms, "1bd792f4-9582-4f26-b69b-19a6a7e8884e.png");

    // Turn the memory stream into a byte[]
    var array = ms.ToArray();

    // Close the memory stream
    ms.Close();

    // Close the FTP connection
    client.Disconnect();

    // Return the file to the user
    return Results.File(array, contentType: "image/png");
});

app.Run();
