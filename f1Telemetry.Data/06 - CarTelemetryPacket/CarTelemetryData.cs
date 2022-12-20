namespace f1Telemetry.Data;
public class CarTelemetryData
{
    private ushort m_speed;                    // Speed of car in kilometres per hour
    private float m_throttle;                 // Amount of throttle applied (0.0 to 1.0)
    private float m_steer;                    // Steering (-1.0 (full lock left) to 1.0 (full lock right))
    private float m_brake;                    // Amount of brake applied (0.0 to 1.0)
    private byte m_clutch;                   // Amount of clutch applied (0 to 100)
    private sbyte m_gear;                     // Gear selected (1-8, N=0, R=-1)
    private ushort m_engineRPM;                // Engine RPM
    private byte m_drs;                      // 0 = off, 1 = on
    private byte m_revLightsPercent;         // Rev lights indicator (percentage)
    private ushort m_revLightsBitValue;        // Rev lights (bit 0 = leftmost LED, bit 14 = rightmost LED)
    readonly ushort[] m_brakesTemperature = new ushort[4];     // Brakes temperature (celsius)
    readonly byte[] m_tyresSurfaceTemperature = new byte[4]; // Tyres surface temperature (celsius)
    readonly byte[] m_tyresInnerTemperature = new byte[4]; // Tyres inner temperature (celsius)
    private ushort m_engineTemperature;        // Engine temperature (celsius)
    readonly float[] m_tyresPressure = new float[4];         // Tyres pressure (PSI)
    readonly byte[] m_surfaceType = new byte[4];           // Driving surface, see appendices

    public static CarTelemetryData FromArray(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        var carTelemetryData = new CarTelemetryData
        {
            m_speed = reader.ReadUInt16(),
            m_throttle = reader.ReadSingle(),
            m_steer = reader.ReadSingle(),
            m_brake = reader.ReadSingle(),
            m_clutch = reader.ReadByte(),
            m_gear = reader.ReadSByte(),
            m_engineRPM = reader.ReadUInt16(),
            m_drs = reader.ReadByte(),
            m_revLightsPercent = reader.ReadByte(),
            m_revLightsBitValue = reader.ReadUInt16()
        };
        for (int i = 0; i < 4; i++)
        {
            carTelemetryData.m_brakesTemperature[i] = reader.ReadUInt16();
        }
        for (int i = 0; i < 4; i++)
        {
            carTelemetryData.m_tyresSurfaceTemperature[i] = reader.ReadByte();
        }
        for (int i = 0; i < 4; i++)
        {
            carTelemetryData.m_tyresInnerTemperature[i] = reader.ReadByte();
        }
        carTelemetryData.m_engineTemperature = reader.ReadUInt16();
        for (int i = 0; i < 4; i++)
        {
            carTelemetryData.m_tyresPressure[i] = reader.ReadSingle();
        }
        for (int i = 0; i < 4; i++)
        {
            carTelemetryData.m_surfaceType[i] = reader.ReadByte();
        }
        return carTelemetryData;
    }
}
