namespace f1Telemetry.Data;
public class WeatherForecastSample
{
    byte m_sessionType; /* 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P, 5 = Q1
                        * 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ
                        * 10 = R, 11 = R2, 12 = R3, 13 = Time Trial
                        */
    byte m_timeOffset; // Time in minutes the forecast is for
    byte m_weather; // Weather - 0 = clear, 1 = light cloud, 2 = overcast 3 = light rain, 4 = heavy rain, 5 = storm
    sbyte m_trackTemperature; // Track temp. in degrees Celsius
    sbyte m_trackTemperatureChange; // Track temp. change – 0 = up, 1 = down, 2 = no change
    sbyte m_airTemperature; // Air temp. in degrees celsius
    sbyte m_airTemperatureChange; // Air temp. change – 0 = up, 1 = down, 2 = no change
    byte m_rainPercentage; // Rain percentage (0-100)

    public static WeatherForecastSample FromArray(byte[] bytes)
    {
        var reader = new BinaryReader(new MemoryStream(bytes));

        return new WeatherForecastSample
        {
            m_sessionType = reader.ReadByte(),
            m_timeOffset = reader.ReadByte(),
            m_weather = reader.ReadByte(),
            m_trackTemperature = reader.ReadSByte(),
            m_trackTemperatureChange = reader.ReadSByte(),
            m_airTemperature = reader.ReadSByte(),
            m_airTemperatureChange = reader.ReadSByte(),
            m_rainPercentage = reader.ReadByte()
        };
    }
}
