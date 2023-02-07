namespace f1Telemetry.Data;
public class WeatherForecastSample
{
    public byte SessionType { get; set; }
    public byte TimeOffset { get; set; }
    public byte Weather { get; set; }
    public sbyte TrackTemperature { get; set; }
    public sbyte TrackTemperatureChange { get; set; }
    public sbyte AirTemperature { get; set; }
    public sbyte AirTemperatureChange { get; set; }
    public byte RainPercentage { get; set; }

    public static WeatherForecastSample FromArray(byte[] data)
    {
        return new()
        {
            SessionType = data[0],
            TimeOffset = data[1],
            Weather = data[2],
            TrackTemperature = (sbyte)data[3],
            TrackTemperatureChange = (sbyte)data[4],
            AirTemperature = (sbyte)data[5],
            AirTemperatureChange = (sbyte)data[6],
            RainPercentage = data[7]
        };
    }
}
