namespace f1Telemetry.Data;
public class PacketLapData
{
    public PacketHeader Header;              // Header

    public LapData[] LapData = new LapData[22];         // Lap data for all cars on track

    public byte TimeTrialPBCarIdx;  // Index of Personal Best car in time trial (255 if invalid)
    public byte TimeTrialRivalCarIdx; 	// Index of Rival car in time trial (255 if invalid)

    public PacketLapData(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        Header = PacketHeader.FromArray(reader.ReadBytes(24));

        for (int i = 0; i < 22; i++)
        {
            LapData[i] = Data.LapData.FromArray(reader.ReadBytes(43));
        }

        TimeTrialPBCarIdx = reader.ReadByte();
        TimeTrialRivalCarIdx = reader.ReadByte();
    }
}
