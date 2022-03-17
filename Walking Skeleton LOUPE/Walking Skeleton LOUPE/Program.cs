using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using Walking_Skeleton_LOUPE.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", (Func<string>)(() => "Hello World!"));

app.MapGet("/employee", (Func<Employee>)(() =>
{
    return new Employee()
    {
        Name = "Youssef",
        Citizenship = "Turks",
        EmployeeId = "1"
    };
}));

app.MapGet("/employees", (Func <List<Employee>>)(() =>
    {
        return new EmployeeCollection().GetEmployees();
    }
));

app.MapGet("/employee/{id}", async (http) =>
{
    if(!http.Request.RouteValues.TryGetValue("id", out var id))
    {
        http.Response.StatusCode = 400;
    }
    else
    {
        await http.Response.WriteAsJsonAsync(new EmployeeCollection().GetEmployees().FirstOrDefault(x => x.EmployeeId == (string)id));
    }
});

app.Run();
