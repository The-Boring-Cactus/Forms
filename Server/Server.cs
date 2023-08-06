using NetCoreServer;
using System.Net.Sockets;
using System.Net;
namespace bpaforms.Server
{
    public class Server : WsServer
    {
        public Server(IPAddress address, int port) : base(address, port) { }


        protected override TcpSession CreateSession() { return new Client(this); }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Server caught an error with code {error}");
        }
    }
}
