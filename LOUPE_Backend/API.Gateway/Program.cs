using Ocelot.DependencyInjection;
using Ocelot.Middleware;

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
var OcelotConfiguration = new OcelotPipelineConfiguration
{
    PreAuthorizationMiddleware = async (ctx, next) =>
    {
        string token = ctx.Request.Headers["Authorization"].ToString().Replace("Bearer", "");

        await next.Invoke();
    }
};

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseContentRoot(Directory.GetCurrentDirectory())
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config
            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
            .AddJsonFile("ocelot.json")
            .AddEnvironmentVariables();
    })
    .ConfigureServices(s =>
    {
        s.AddOcelot();
        s.AddControllers();
        s.AddSwaggerForOcelot(configuration);
    });

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseAuthentication();
app.UseAuthorization();

app.UseOcelot(OcelotConfiguration).Wait();

app.Run();
