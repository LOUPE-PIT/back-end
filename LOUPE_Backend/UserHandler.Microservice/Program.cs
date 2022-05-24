using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Context;
using User.Microservice.Data;
using User.Microservice.Model;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
var authenticationProviderKey = "UserKey";

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddAuthentication()
    .AddJwtBearer(authenticationProviderKey, options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
            ValidAudience = "apiUsers",
            ValidIssuer = "apiIssuer",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/user/login/{id}", ([FromServices] IUserDAL db, string id) =>
{
    return db.GetUserById(id);
});

app.MapDelete("/user/delete/{id}", ([FromServices] IUserDAL db, string id) =>
{
    return db.DeleteUserById(id);
});

app.MapGet("/user/all", ([FromServices] IUserDAL db) =>
{
    return db.GetUsers();
});

app.MapPut("/user/update/{id}", ([FromServices] IUserDAL db, UserModel user) =>
{
    db.UpdateUser(user);
});

app.MapPost("/user/add", ([FromServices] IUserDAL db, UserModel user) =>
{
    db.AddUser(user);
});

app.MapPost("/user/jwt/login", (UserModel user) =>
{
    return GenerateToken(user);
});

IResult GenerateToken(UserModel user)
{
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]));
    var credentials =new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
    var expirationDate = DateTime.Now.AddHours(2);

    var claims = new[]
    {
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Name, user.name),
        new Claim("Role", "Admin")
    };

    var token = new JwtSecurityToken(audience: "apiUsers",
                                        issuer: "apiIssuer",
                                        claims: claims,
                                        expires: expirationDate,
                                        signingCredentials: credentials);

    var authToken = new JwtSecurityTokenHandler().WriteToken(token);

    return Results.Ok(authToken);

}

app.Run();

public partial class Program { }