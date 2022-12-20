namespace f1Telemetry.Data;
public class FinalClassificationData
{
    sbyte m_position; // Finishing position
    sbyte m_numLaps; // Number of laps completed
    sbyte m_gridposition; // Grid position of the car
    sbyte m_points; // Number of points scored
    sbyte m_numPitStops; // Number of pit stops made
    sbyte m_resultStatus; // Result status - 0 = invalid, 1 = inactive, 2 = active
                        // 3 = finished, 4 = didnotfinish, 5 = disqualified
                        // 6 = not classified, 7 = retired
    uint m_bestLapTimeInMS; // Best lap time of the session in milliseconds
    double m_totalRaceTime; // Total race time in seconds without penalties
    sbyte m_penaltiesTime; // Total penalties accumulated in seconds
    sbyte m_numPenalties; // Number of penalties applied to this driver
    sbyte m_numTyreStints; // Number of tyres stints up to maximum
    readonly sbyte[] m_tyreStintsActual = new sbyte[8]; // Actual tyres used by this driver
    readonly sbyte[] m_tyreStintsVisual = new sbyte[8]; // Visual tyres used by this driver
    readonly sbyte[] m_tyreStintsEndLaps = new sbyte[8]; // The lap number stints end on

    public static FinalClassificationData FromArray(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        var res = new FinalClassificationData
        {
            m_position = reader.ReadSByte(),
            m_numLaps = reader.ReadSByte(),
            m_gridposition = reader.ReadSByte(),
            m_points = reader.ReadSByte(),
            m_numPitStops = reader.ReadSByte(),
            m_resultStatus = reader.ReadSByte(),
            m_bestLapTimeInMS = reader.ReadUInt32(),
            m_totalRaceTime = reader.ReadDouble(),
            m_penaltiesTime = reader.ReadSByte(),
            m_numPenalties = reader.ReadSByte(),
            m_numTyreStints = reader.ReadSByte(),
        };
        for (int i = 0; i < 8; i++)
        {
            res.m_tyreStintsActual[i] = reader.ReadSByte();
        }
        for (int i = 0; i < 8; i++)
        {
            res.m_tyreStintsVisual[i] = reader.ReadSByte();
        }
        for (int i = 0; i < 8; i++)
        {
            res.m_tyreStintsEndLaps[i] = reader.ReadSByte();
        }
        return res;
    }
}
