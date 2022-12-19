namespace f1Telemetry.Data;

public class PacketCarDamageData
{
    readonly PacketHeader m_header;

    readonly CarDamageData[] m_carDamageData = new CarDamageData[22];
    public PacketCarDamageData(byte[] packet){
        var reader = new BinaryReader(new MemoryStream(packet));
        m_header = PacketHeader.FromArray(reader.ReadBytes(24));

        for (int i = 0; i < 22; i++)
        {
            m_carDamageData[i] = CarDamageData.FromArray(reader.ReadBytes(42));
        }
    }
}