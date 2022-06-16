using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(config =>
{
    var user = builder.Configuration["rabbitmq:user"];
    var password = builder.Configuration["rabbitmq:password"];
    var ipaddress = builder.Configuration["rabbitmq:ip-address"];

    config.UsingRabbitMq((ctx, cfg) =>
    {
        // Connect to RabbitMQ server;
        cfg.Host("amqp://" + user + ":" + password + "@" + ipaddress);
    });
});
builder.Services.AddMassTransitHostedService();

// App:
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
