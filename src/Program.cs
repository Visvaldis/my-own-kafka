using System.Buffers.Binary;
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
        var message = await stream.ReadMessageAsync<Message<HeaderV2>>(1024);
        Console.WriteLine(message.Header.CorrelationId);
        byte[] correlationIdBytes = new byte[4];
        BinaryPrimitives.WriteInt32BigEndian(correlationIdBytes, message.Header.CorrelationId);
        

        await stream.WriteAsync(correlationIdBytes, 0, correlationIdBytes.Length);
        await stream.WriteAsync(correlationIdBytes, 0, correlationIdBytes.Length);
        await stream.FlushAsync();
    }
    finally
    {
        server.Stop();
        client.Close();
    }
}

await Main();