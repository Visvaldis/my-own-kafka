using System.Buffers.Binary;
using codecraftersKafka.Models.Headers;

namespace codecraftersKafka.Models;

public class Message<HeaderT>: IMessage where HeaderT : IHeader, new()
{
    public int MessageSize { get; set; }

    public HeaderT Header { get; set; }


    public byte[] ToByteArray()
    {
        byte[] messageSizeBytes = BitConverter.GetBytes(MessageSize);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(messageSizeBytes);
        }
        byte[] headerBytes = Header.ToByteArray();

        return messageSizeBytes.Concat(headerBytes).ToArray();
    }

    public IMessage FromByteArray(byte[] data)
    {

        MessageSize = BinaryPrimitives.ReadInt32BigEndian(data[..4]);
        Header = new HeaderT();
        Header.FromByteArray(data[4..]);

        return this;
    }
}