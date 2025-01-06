namespace codecraftersKafka.Models;

public interface IMessage
{
    byte[] ToByteArray();
    void FromByteArray(byte[] data);
}