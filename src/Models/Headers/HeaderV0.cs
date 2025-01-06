namespace codecraftersKafka.Models.Headers;

using System.Text;

public class HeaderV0 : IHeader
{
    public int CorrelationId { get; set; }
    
    
    public byte[] ToByteArray()
    {
        var correlationIdBytes = BitConverter.GetBytes(CorrelationId);
        
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(correlationIdBytes);
        }

        return correlationIdBytes;
    }

    public IHeader FromByteArray(byte[] data)
    {
        throw new NotImplementedException();
    }
}