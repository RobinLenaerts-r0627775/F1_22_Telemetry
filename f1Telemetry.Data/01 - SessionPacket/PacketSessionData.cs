namespace f1Telemetry.Data;
public class PacketSessionData
{
    public PacketHeader Header { get; set; }

    public byte Weather { get; set; }

    public sbyte TrackTemperature { get; set; }

    public sbyte AirTemperature { get; set; }

    public byte TotalLaps { get; set; }

    public ushort TrackLength { get; set; }

    public byte SessionType { get; set; }

    public sbyte TrackId { get; set; }

    public byte Formula { get; set; }

    public ushort SessionTimeLeft { get; set; }

    public ushort SessionDuration { get; set; }

    public byte PitSpeedLimit { get; set; }

    public byte GamePaused { get; set; }

    public byte IsSpectating { get; set; }

    public byte SpectatorCarIndex { get; set; }

    public byte SliProNativeSupport { get; set; }

    public byte NumMarshalZones { get; set; }

    public MarshalZone[] MarshalZones { get; set; }

    public byte SafetyCarStatus { get; set; }

    public byte NetworkGame { get; set; }

    public byte NumWeatherForecastSamples { get; set; }

    public WeatherForecastSample[] WeatherForecastSamples { get; set; }

    public byte ForecastAccuracy { get; set; }

    public byte AiDifficulty { get; set; }

    public uint SeasonLinkIdentifier { get; set; }

    public uint WeekendLinkIdentifier { get; set; }

    public uint SessionLinkIdentifier { get; set; }

    public byte PitStopWindowIdealLap { get; set; }

    public byte PitStopWindowLatestLap { get; set; }

    public byte PitStopRejoinPosition { get; set; }

    public byte SteeringAssist { get; set; }

    public byte BrakingAssist { get; set; }

    public byte GearboxAssist { get; set; }

    public byte PitAssist { get; set; }

    public byte PitReleaseAssist { get; set; }

    public byte ErsAssist { get; set; }

    public byte DrsAssist { get; set; }

    public byte DynamicRacingLine { get; set; }

    public byte DynamicRacingLineType { get; set; }

    public byte GameMode { get; set; }

    public byte RuleSet { get; set; }

    public uint TimeOfDay { get; set; }

    public byte SessionLength { get; set; }

    public PacketSessionData(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        Header = PacketHeader.FromArray(reader.ReadBytes(24));

        Weather = reader.ReadByte();
        TrackTemperature = reader.ReadSByte();
        AirTemperature = reader.ReadSByte();
        TotalLaps = reader.ReadByte();
        TrackLength = reader.ReadUInt16();
        SessionType = reader.ReadByte();
        TrackId = reader.ReadSByte();
        Formula = reader.ReadByte();
        SessionTimeLeft = reader.ReadUInt16();
        SessionDuration = reader.ReadUInt16();
        PitSpeedLimit = reader.ReadByte();
        GamePaused = reader.ReadByte();
        IsSpectating = reader.ReadByte();
        SpectatorCarIndex = reader.ReadByte();
        SliProNativeSupport = reader.ReadByte();
        NumMarshalZones = reader.ReadByte();
        MarshalZones = new MarshalZone[NumMarshalZones];
        for (int i = 0; i < NumMarshalZones; i++)
        {
            MarshalZones[i] = MarshalZone.FromArray(reader.ReadBytes(5));
        }
        SafetyCarStatus = reader.ReadByte();
        NetworkGame = reader.ReadByte();
        NumWeatherForecastSamples = reader.ReadByte();
        WeatherForecastSamples = new WeatherForecastSample[NumWeatherForecastSamples];
        for (int i = 0; i < NumWeatherForecastSamples; i++)
        {
            WeatherForecastSamples[i] = WeatherForecastSample.FromArray(reader.ReadBytes(8));
        }

        ForecastAccuracy = reader.ReadByte();
        AiDifficulty = reader.ReadByte();
        SeasonLinkIdentifier = reader.ReadUInt32();
        WeekendLinkIdentifier = reader.ReadUInt32();
        SessionLinkIdentifier = reader.ReadByte();
        PitStopWindowIdealLap = reader.ReadByte();
        PitStopWindowLatestLap = reader.ReadByte();
        PitStopRejoinPosition = reader.ReadByte();
        SteeringAssist = reader.ReadByte();
        BrakingAssist = reader.ReadByte();
        GearboxAssist = reader.ReadByte();
        PitAssist = reader.ReadByte();
        PitReleaseAssist = reader.ReadByte();
        ErsAssist = reader.ReadByte();
        DrsAssist = reader.ReadByte();
        DynamicRacingLine = reader.ReadByte();
        DynamicRacingLineType = reader.ReadByte();
        GameMode = reader.ReadByte();
        RuleSet = reader.ReadByte();
        TimeOfDay = reader.ReadUInt32();
        SessionLength = reader.ReadByte();
    }
}