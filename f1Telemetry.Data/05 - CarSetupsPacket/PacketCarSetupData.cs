
namespace f1Telemetry.Data;
public class PacketCarSetupData
{
    readonly PacketHeader m_header; // Header

    readonly CarSetupData[] m_carSetups = new CarSetupData[22];

    public PacketCarSetupData(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        m_header = PacketHeader.FromArray(reader.ReadBytes(24));

        for (int i = 0; i < 22; i++)
        {
            var bytes = reader.ReadBytes(1102);
            m_carSetups[i] = CarSetupData.FromArray(bytes);
        }
    }
}
