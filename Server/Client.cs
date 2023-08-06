using System.Net.Sockets;
using System.Text;
using NetCoreServer;
using Newtonsoft.Json;
namespace bpaforms.Server
{
    public class Client : WsSession
    {
        private bool login = false;
        public Client(WsServer server) : base(server) { }
        public override void OnWsConnected(HttpRequest request)
        {
            Console.WriteLine($"Client session with Id {Id} connected!");

            // Send loging message
            var msg = new MSkel() { Comand = "Login" };
            string message = JsonConvert.SerializeObject(msg);
            SendTextAsync(message);
        }
        public override void OnWsDisconnected()
        {
            Console.WriteLine($"Client session with Id {Id} disconnected!");
        }
        public override void OnWsReceived(byte[] buffer, long offset, long size)
        {
            string msg = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            if(msg!=null){
                MSkel? message = JsonConvert.DeserializeObject<MSkel>(msg);

                Console.WriteLine("Incoming: " + message);

            }
        }
        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Client session caught an error with code {error}");
        }
    }
}