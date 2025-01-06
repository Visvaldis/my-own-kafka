using System.Buffers.Binary;
using System.Text;

namespace codecraftersKafka.Models.Headers;

public class HeaderV2: IHeader
{
    public short RequestApiKey { get; set; }
    public short RequestApiVersion { get; set; }
    public int CorrelationId { get; set; }
    public string ClientId { get; set; }
    
    
    public byte[] ToByteArray()
    {
        throw new NotImplementedException();
    }

    public IHeader FromByteArray(byte[] data)
    {
        RequestApiKey = BinaryPrimitives.ReadInt16BigEndian(data[..2]);
        RequestApiVersion = BinaryPrimitives.ReadInt16BigEndian(data[2..4]);
        CorrelationId = BinaryPrimitives.ReadInt32BigEndian(data[4..8]);
        ClientId = Encoding.Default.GetString(data[8..]);
        return this;
    }
}