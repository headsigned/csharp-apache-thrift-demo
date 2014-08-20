namespace Server
{
    using System;
    using System.Threading;
    using Common.ThriftInterface;
    using Thrift.Server;
    using Thrift.Transport;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var handler = new LibraryServiceHandler();
            var processor = new LibraryService.Processor(handler);

            TServerTransport transport = new TServerSocket(9090);
            TServer server = new TThreadPoolServer(processor, transport); // TThreadPoolServer accepts multiple clients

            Console.WriteLine("Starting the server...");

            // Start server on a different background thread so the console continues to be responsive
            var serverThread = new Thread(() => server.Serve()) { IsBackground = true };
            serverThread.Start();

            Console.WriteLine("Done. Press any key to stop the server...");
            Console.ReadKey(true);

            server.Stop();
        }
    }
}
