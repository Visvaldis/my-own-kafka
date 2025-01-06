using codecraftersKafka.Models.Headers;

namespace codecraftersKafka.Models;

public class Message: IMessage
{
    public int MessageSize { get; set; }

    public IHeader Header { get; set; }


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

    public void FromByteArray(byte[] data)
    {
        throw new NotImplementedException();
    }
}