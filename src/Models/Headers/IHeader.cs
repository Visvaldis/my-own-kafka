namespace codecraftersKafka.Models.Headers;

public interface IHeader
{
    byte[] ToByteArray();
    void FromByteArray(byte[] data);
}