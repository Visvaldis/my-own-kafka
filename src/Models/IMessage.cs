namespace codecraftersKafka.Models;

public interface IMessage
{
    byte[] ToByteArray();
    IMessage? FromByteArray(byte[] data);
}