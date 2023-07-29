using Raven.Embedded;
using System.Net;
using bpaforms.Server;

internal class Program
{
    private static void Main(string[] args)
    {
        EmbeddedServer.Instance.StartServer();

        int port = 8080;

        string www = "./www";

        Console.WriteLine($"WebSocket server port: {port}");
        Console.WriteLine($"WebSocket server static content path: {www}");
        Console.WriteLine($"WebSocket server website: http://*:{port}/index.html");
        Console.WriteLine();

        var server = new Server(IPAddress.Any, port);
        server.AddStaticContent(www, "/");
        Console.Write("Server starting...");
        var isok = server.Start();
        Console.WriteLine($"WebSocket ok: {isok}");

        for (; ; )
        {
            string? line = Console.ReadLine();
            if (string.Equals(line, "Stop"))
                break;

            // Restart the server
            if (string.Equals(line, "Restart"))
            {
                Console.Write("Server restarting...");
                server.Restart();
                Console.WriteLine("Done!");
            }

            // Multicast admin message to all sessions
            line = "(server) " + line;
            server.MulticastText(line);
        }

        // Stop the server
        Console.Write("Server stopping...");
        server.Stop();
        Console.WriteLine("Done!");
    }
}