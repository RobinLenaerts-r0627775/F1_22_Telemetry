namespace f1Telemetry.Data;
public class FinalClassificationData
{
    byte m_position; // Finishing position
    byte m_numLaps; // Number of laps completed
    byte m_gridposition; // Grid position of the car
    byte m_points; // Number of points scored
    byte m_numPitStops; // Number of pit stops made
    byte m_resultStatus; // Result status - 0 = invalid, 1 = inactive, 2 = active
                        // 3 = finished, 4 = didnotfinish, 5 = disqualified
                        // 6 = not classified, 7 = retired
    uint m_bestLapTimeInMS; // Best lap time of the session in milliseconds
    double m_totalRaceTime; // Total race time in seconds without penalties
    byte m_penaltiesTime; // Total penalties accumulated in seconds
    byte m_numPenalties; // Number of penalties applied to this driver
    byte m_numTyreStints; // Number of tyres stints up to maximum
    readonly byte[] m_tyreStintsActual = new byte[8]; // Actual tyres used by this driver
    readonly byte[] m_tyreStintsVisual = new byte[8]; // Visual tyres used by this driver
    readonly byte[] m_tyreStintsEndLaps = new byte[8]; // The lap number stints end on

    public static FinalClassificationData FromArray(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        var res = new FinalClassificationData
        {
            m_position = reader.ReadByte(),
            m_numLaps = reader.ReadByte(),
            m_gridposition = reader.ReadByte(),
            m_points = reader.ReadByte(),
            m_numPitStops = reader.ReadByte(),
            m_resultStatus = reader.ReadByte(),
            m_bestLapTimeInMS = reader.ReadUInt32(),
            m_totalRaceTime = reader.ReadDouble(),
            m_penaltiesTime = reader.ReadByte(),
            m_numPenalties = reader.ReadByte(),
            m_numTyreStints = reader.ReadByte(),
        };
        for (int i = 0; i < 8; i++)
        {
            res.m_tyreStintsActual[i] = reader.ReadByte();
        }
        for (int i = 0; i < 8; i++)
        {
            res.m_tyreStintsVisual[i] = reader.ReadByte();
        }
        for (int i = 0; i < 8; i++)
        {
            res.m_tyreStintsEndLaps[i] = reader.ReadByte();
        }
        return res;
    }
}
