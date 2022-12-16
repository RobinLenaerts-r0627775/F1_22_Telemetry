namespace f1Telemetry.Data;
public class PacketLapData
{
    public PacketHeader m_header;              // Header

    public LapData[] m_lapData = new LapData[22];         // Lap data for all cars on track

    public byte m_timeTrialPBCarIdx;  // Index of Personal Best car in time trial (255 if invalid)
    public byte m_timeTrialRivalCarIdx; 	// Index of Rival car in time trial (255 if invalid)

    public PacketLapData(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        m_header = PacketHeader.FromArray(reader.ReadBytes(24));

        for (int i = 0; i < 22; i++)
        {
            m_lapData[i] = LapData.FromArray(reader.ReadBytes(43));
        }

        m_timeTrialPBCarIdx = reader.ReadByte();
        m_timeTrialRivalCarIdx = reader.ReadByte();
    }
}
