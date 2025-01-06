namespace codecraftersKafka.Models.Headers;

public interface IHeader
{
    byte[] ToByteArray();
    IHeader FromByteArray(byte[] data);
}