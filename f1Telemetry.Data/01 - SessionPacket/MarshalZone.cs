namespace f1Telemetry.Data;
public class MarshalZone
{
    float m_zoneStart; // Fraction (0..1) of way through the lap the marshal zone starts
    SByte m_zoneFlag; // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red

    public static MarshalZone FromArray(byte[] bytes)
    {
        var reader = new BinaryReader(new MemoryStream(bytes));

        return new MarshalZone
        {
            m_zoneStart = reader.ReadSingle(),
            m_zoneFlag = reader.ReadSByte()
        };
    }
}