using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;

namespace Lab2
{
    public class Client
    {
        WebSocket socket;

        public async void Send()
        {
            int i= 0;
            byte[] buffer = new byte[4096];

            while (socket != null && socket.State == WebSocketState.Open)
            {
                string currentTime = DateTime.Now.ToString("HH:mm:ss");
                buffer = Encoding.ASCII.GetBytes($"Message: {++i}, Current Time: {currentTime}");
                await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                Thread.Sleep(2000);
            }
        }


        public async void Receive()
        {
            byte[] buffer = new byte[4096];
            string message;

            Console.WriteLine("Запуск обмена");
            while (socket != null && socket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine(message);
            }
            Console.WriteLine("Завершение обмена");
        }


        public Client(WebSocket socket)
        {
            this.socket = socket;
        }
    }
}
