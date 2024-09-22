using Lab2;
using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("index.html");
});

app.UseWebSockets();

app.MapGet("/socket", async (HttpContext context) =>
{
    if (context.WebSockets.IsWebSocketRequest)                                                                          
    {
        WebSocket socket = await context.WebSockets.AcceptWebSocketAsync();
        Client client = new Client(socket);

        Thread SendThread = new Thread(client.Send);
        Thread ReciveThread = new Thread(client.Receive);

        SendThread.Start();
        ReciveThread.Start();

        SendThread.Join();
        ReciveThread.Join();
    }
});

app.Run();


