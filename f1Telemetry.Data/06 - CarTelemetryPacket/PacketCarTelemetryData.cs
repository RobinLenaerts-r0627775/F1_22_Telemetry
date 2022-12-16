namespace f1Telemetry.Data;
public class PacketCarTelemetryData
{
    readonly PacketHeader m_header;        // Header
    readonly CarTelemetryData[] m_carTelemetryData = new CarTelemetryData[22];
    readonly byte m_mfdPanelIndex;       /* Index of MFD panel open - 255 = MFD closed
                                    * Single player, race – 0 = Car setup, 1 = Pits
                                    * 2 = Damage, 3 =  Engine, 4 = Temperatures
                                    * May vary depending on game mode
                                    */
    readonly byte m_mfdPanelIndexSecondaryPlayer;   // See above
    readonly sbyte m_suggestedGear;       // Suggested gear for the player (1-8)
                                    // 0 if no gear suggested
    public PacketCarTelemetryData(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        m_header = PacketHeader.FromArray(reader.ReadBytes(24));
        for (int i = 0; i < 22; i++)
        {
            var bytes = reader.ReadBytes(1347);
            m_carTelemetryData[i] = CarTelemetryData.FromArray(bytes);
        }
        m_mfdPanelIndex = reader.ReadByte();
        m_mfdPanelIndexSecondaryPlayer = reader.ReadByte();
        m_suggestedGear = reader.ReadSByte();
    }
}