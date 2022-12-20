namespace f1Telemetry.Data;
public class PacketFinalClassificationData
{
    public PacketHeader m_header;
    readonly byte m_numCars;          // Number of cars in the final classification
    readonly FinalClassificationData[] m_classificationData = new FinalClassificationData[22];

    public PacketFinalClassificationData(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        m_header = PacketHeader.FromArray(reader.ReadBytes(24));

        m_numCars = reader.ReadByte();
        for (int i = 0; i < 22; i++)
        {
            m_classificationData[i] = FinalClassificationData.FromArray(reader.ReadBytes(45));
        }
    }
}