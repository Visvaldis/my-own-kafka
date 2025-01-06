using System.Net.Sockets;
using codecraftersKafka.Models;

namespace codecraftersKafka.Extentions;

public static class NetworkStreamExtensions
{
    public static async Task WriteMessageAsync(this NetworkStream stream, IMessage message)
    {
        var data = message.ToByteArray();
        await stream.WriteAsync(data, 0, data.Length);
    }

    public static async Task<T> ReadMessageAsync<T>(this NetworkStream stream, int size) where T : IMessage, new()
    {
        var buffer = new byte[size];
        await stream.ReadAsync(buffer, 0, size);
        var message = new T();
        message.FromByteArray(buffer);
        return message;
    }
}
