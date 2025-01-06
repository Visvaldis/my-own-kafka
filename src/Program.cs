using System.Net;
using System.Net.Sockets;
using System.Text;
using codecraftersKafka.Extentions;
using codecraftersKafka.Models;
using codecraftersKafka.Models.Headers;

async Task Main()
{
    // You can use print statements as follows for debugging, they'll be visible when running tests.
    Console.WriteLine("Logs from your program will appear here!");

    TcpListener server = new TcpListener(IPAddress.Any, 9092);
    server.Start();

    var client = await server.AcceptTcpClientAsync(); // wait for client
    try
    {
        var stream = client.GetStream();

        var message = new Message
        {
            MessageSize = 4,
            Header = new HeaderV0 { CorrelationId = 7 }
        };
        
        await stream.WriteMessageAsync(message);
        await stream.FlushAsync();
    }
    finally
    {
        server.Stop();
        client.Close();
    }
}

await Main();