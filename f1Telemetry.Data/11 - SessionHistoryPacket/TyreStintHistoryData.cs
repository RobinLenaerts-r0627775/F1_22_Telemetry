namespace f1Telemetry.Data;

public class TyreStintHistoryData
{
    byte m_endLap;                // Lap the tyre usage ends on (255 of current tyre)
    byte m_tyreActualCompound;    // Actual tyres used by this driver
    byte m_tyreVisualCompound;    // Visual tyres used by this driver

    public static TyreStintHistoryData FromArray(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        return new TyreStintHistoryData{
            m_endLap = reader.ReadByte(),
            m_tyreActualCompound = reader.ReadByte(),
            m_tyreVisualCompound = reader.ReadByte()
        };
    }
}