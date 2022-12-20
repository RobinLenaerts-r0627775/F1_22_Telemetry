namespace f1Telemetry.Data;

public class PacketSessionHistoryData
{
    readonly PacketHeader m_header;
    readonly byte m_carIdx;                   // Index of the car this lap data relates to
    readonly byte m_numLaps;                  // Num laps in the data (including current partial lap)
    readonly byte m_numTyreStints;            // Number of tyre stints in the data

    readonly byte m_bestLapTimeLapNum;        // Lap the best lap time was achieved on
    readonly byte m_bestSector1LapNum;        // Lap the best Sector 1 time was achieved on
    readonly byte m_bestSector2LapNum;        // Lap the best Sector 2 time was achieved on
    readonly byte m_bestSector3LapNum;        // Lap the best Sector 3 time was achieved on

    readonly LapHistoryData[] m_lapHistoryData = new LapHistoryData[100];	// 100 laps of data max
    readonly TyreStintHistoryData[] m_tyreStintsHistoryData = new TyreStintHistoryData[8];

    public PacketSessionHistoryData(byte[] packet){
        var reader = new BinaryReader(new MemoryStream(packet));
        m_header = PacketHeader.FromArray(reader.ReadBytes(24));
        m_carIdx = reader.ReadByte();
        m_numLaps = reader.ReadByte();
        m_numTyreStints = reader.ReadByte();
        m_bestLapTimeLapNum = reader.ReadByte();
        m_bestSector1LapNum = reader.ReadByte();
        m_bestSector2LapNum = reader.ReadByte();
        m_bestSector3LapNum = reader.ReadByte();
        for (int i = 0; i < 100; i++)
        {
            m_lapHistoryData[i] = LapHistoryData.FromArray(reader.ReadBytes(11));
        }
        for (int i = 0; i < 8; i++)
        {
            m_tyreStintsHistoryData[i] = TyreStintHistoryData.FromArray(reader.ReadBytes(3));
        }
    }
}