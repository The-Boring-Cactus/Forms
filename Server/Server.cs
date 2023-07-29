using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
