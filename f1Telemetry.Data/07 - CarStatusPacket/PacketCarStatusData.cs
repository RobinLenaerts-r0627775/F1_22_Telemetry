namespace f1Telemetry.Data;
public class PacketCarStatusData
{
    readonly PacketHeader m_header;	   // Header

    readonly CarStatusData[] m_carStatusData = new CarStatusData[22];

    public PacketCarStatusData(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        m_header = PacketHeader.FromArray(reader.ReadBytes(24));

        var bytes = reader.ReadBytes(1034);
        for (int i = 0; i < 22; i++)
        {
            m_carStatusData[i] = CarStatusData.FromArray(bytes);
        }
    }
}
