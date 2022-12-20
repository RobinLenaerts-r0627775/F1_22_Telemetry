namespace f1Telemetry.Data;

public class LapHistoryData
{
    uint m_lapTimeInMS;           // Lap time in milliseconds
    ushort m_sector1TimeInMS;       // Sector 1 time in milliseconds
    ushort m_sector2TimeInMS;       // Sector 2 time in milliseconds
    ushort m_sector3TimeInMS;       // Sector 3 time in milliseconds
    byte m_lapValidBitFlags;      // 0x01 bit set-lap valid,      0x02 bit set-sector 1 valid
                                   // 0x04 bit set-sector 2 valid, 0x08 bit set-sector 3 valid
    public static LapHistoryData FromArray(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        return new LapHistoryData{
            m_lapTimeInMS = reader.ReadUInt32(),
            m_sector1TimeInMS = reader.ReadUInt16(),
            m_sector2TimeInMS = reader.ReadUInt16(),
            m_sector3TimeInMS = reader.ReadUInt16(),
            m_lapValidBitFlags = reader.ReadByte()
        };
    }
}