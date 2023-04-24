using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthenticationService.DataLayer.Models.User;
using AuthenticationService.DataLayer.Services;
using AuthenticationService.DataLayer.Context;


var builder = WebApplication.CreateBuilder(args);
var authenticationProviderKey = "UserKey";

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IAuthenticationDAL, AuthenticationDAL>();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
   {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
   });
});

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


// Automatically Migrate the database
// Need database connection to have this code work. Results in error otherwise.
using (var scope = app.Services.CreateScope())
{
    var y = scope.ServiceProvider.GetRequiredService<UserDbContext>();
    y.Database.Migrate();
}


//if (app.Environment.IsDevelopment())
//{
app.UseDeveloperExceptionPage();
// Add swagger
app.UseSwagger();
app.UseSwaggerUI();
//}

app.MapGet("/user/login/{Guid}", ([FromServices] IAuthenticationDAL db, Guid id) =>
{
    return db.GetUserById(id);
});

app.MapDelete("/user/delete/{Guid}", ([FromServices] IAuthenticationDAL db, Guid id) =>
{
    return db.DeleteUserById(id);
});

app.MapGet("/user/all", ([FromServices] IAuthenticationDAL db) =>
{
    return db.GetUsers();
});

app.MapPut("/user/update/{id}", ([FromServices] IAuthenticationDAL db, UserModel user) =>
{
    db.UpdateUser(user);
});

app.MapPost("/user/add", ([FromServices] IAuthenticationDAL db, UserModel user) =>
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
    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
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