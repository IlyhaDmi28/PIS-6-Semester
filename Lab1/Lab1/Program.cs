using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/DII", (string ParmA, string ParmB, HttpContext httpContext) => 
{
    httpContext.Response.ContentType = "text/plain";
    return $"GET-Http-DII:ParmA = {ParmA}, ParmB = {ParmB}";
});



app.MapPost("/DII", (HttpContext httpContext) =>
{
    string ParmA = httpContext.Request.Form["ParmA"];
    string ParmB = httpContext.Request.Form["ParmB"];
    httpContext.Response.ContentType = "text/plain";

    return $"POST-Http-DII:ParmA = {ParmA}, ParmB = {ParmB}"; ;
});

app.MapPut("/DII", (HttpContext httpContext) =>
{
    string ParmA = httpContext.Request.Form["ParmA"];
    string ParmB = httpContext.Request.Form["ParmB"];
    httpContext.Response.ContentType = "text/plain";

    return $"PUT-Http-DII:ParmA = {ParmA}, ParmB = {ParmB}"; ;
});


app.MapPost("/sum", async (HttpContext context) =>
{
    int xValue = int.Parse(context.Request.Form["x"]);
    int yValue = int.Parse(context.Request.Form["y"]);
    string result = (xValue + yValue).ToString();
    await context.Response.WriteAsync(result, Encoding.UTF8);
});


app.MapGet("/multiplication1", async (HttpContext httpContext) =>
{
    httpContext.Response.ContentType = "text/html";

    string html = await File.ReadAllTextAsync("multiplication1.html");
    await httpContext.Response.WriteAsync(html, Encoding.UTF8);
});

app.MapPost("/multiplication1", async (HttpContext context) =>
{
    int xValue = int.Parse(context.Request.Form["x"]);
    int yValue = int.Parse(context.Request.Form["y"]);
    string result = (xValue * yValue).ToString();
    await context.Response.WriteAsync(result, Encoding.UTF8);
});


app.MapGet("/multiplication2", async (HttpContext httpContext) =>
{
    httpContext.Response.ContentType = "text/html";

    string html = await File.ReadAllTextAsync("multiplication2.html");
    await httpContext.Response.WriteAsync(html, Encoding.UTF8);
});

app.MapPost("/multiplication2", async (HttpContext context) =>
{
    int xValue = int.Parse(context.Request.Form["x"]);
    int yValue = int.Parse(context.Request.Form["y"]);
    string result = (xValue * yValue).ToString();
    await context.Response.WriteAsync(result, Encoding.UTF8);
});


app.Run();
