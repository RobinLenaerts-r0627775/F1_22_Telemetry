namespace f1Telemetry.Data;
public class CarStatusData
{
    byte m_tractionControl;          // Traction control - 0 = off, 1 = medium, 2 = full
    byte m_antiLockBrakes;           // 0 (off) - 1 (on)
    byte m_fuelMix;                  // Fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max
    byte m_frontBrakeBias;           // Front brake bias (percentage)
    byte m_pitLimiterStatus;         // Pit limiter status - 0 = off, 1 = on
    float m_fuelInTank;               // Current fuel mass
    float m_fuelCapacity;             // Fuel capacity
    float m_fuelRemainingLaps;        // Fuel remaining in terms of laps (value on MFD)
    ushort m_maxRPM;                   // Cars max RPM, point of rev limiter
    ushort m_idleRPM;                  // Cars idle RPM
    byte m_maxGears;                 // Maximum number of gears
    byte m_drsAllowed;               // 0 = not allowed, 1 = allowed
    ushort m_drsActivationDistance;    // 0 = DRS not available, non-zero - DRS will be available
                                       // in [X] metres

    byte m_actualTyreCompound;    // F1 Modern - 16 = C5, 17 = C4, 18 = C3, 19 = C2, 20 = C1
                                   // 7 = inter, 8 = wet
                                   // F1 Classic - 9 = dry, 10 = wet
                                   // F2 – 11 = super soft, 12 = soft, 13 = medium, 14 = hard
                                   // 15 = wet

    byte m_visualTyreCompound;       // F1 visual (can be different from actual compound)
                                      // 16 = soft, 17 = medium, 18 = hard, 7 = inter, 8 = wet
                                      // F1 Classic – same as above
                                      // F2 ‘19, 15 = wet, 19 – super soft, 20 = soft
                                      // 21 = medium , 22 = hard

    byte m_tyresAgeLaps;             // Age in laps of the current set of tyres
    sbyte m_vehicleFiaFlags;    // -1 = invalid/unknown, 0 = none, 1 = green
                               // 2 = blue, 3 = yellow, 4 = red

    float m_ersStoreEnergy;           // ERS energy store in Joules
    byte m_ersDeployMode;            // ERS deployment mode, 0 = none, 1 = medium
                                      // 2 = hotlap, 3 = overtake

    float m_ersHarvestedThisLapMGUK;  // ERS energy harvested this lap by MGU-K
    float m_ersHarvestedThisLapMGUH;  // ERS energy harvested this lap by MGU-H
    float m_ersDeployedThisLap;       // ERS energy deployed this lap
    byte m_networkPaused;            // Whether the car is paused in a network game

    public static CarStatusData FromArray(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        return new CarStatusData
        {
            m_tractionControl = reader.ReadByte(),
            m_antiLockBrakes = reader.ReadByte(),
            m_fuelMix = reader.ReadByte(),
            m_frontBrakeBias = reader.ReadByte(),
            m_pitLimiterStatus = reader.ReadByte(),
            m_fuelInTank = reader.ReadSingle(),
            m_fuelCapacity = reader.ReadSingle(),
            m_fuelRemainingLaps = reader.ReadSingle(),
            m_maxRPM = reader.ReadUInt16(),
            m_idleRPM = reader.ReadUInt16(),
            m_maxGears = reader.ReadByte(),
            m_drsAllowed = reader.ReadByte(),
            m_drsActivationDistance = reader.ReadUInt16(),
            m_actualTyreCompound = reader.ReadByte(),
            m_visualTyreCompound = reader.ReadByte(),
            m_tyresAgeLaps = reader.ReadByte(),
            m_vehicleFiaFlags = reader.ReadSByte(),
            m_ersStoreEnergy = reader.ReadSingle(),
            m_ersDeployMode = reader.ReadByte(),
            m_ersHarvestedThisLapMGUK = reader.ReadSingle(),
            m_ersHarvestedThisLapMGUH = reader.ReadSingle(),
            m_ersDeployedThisLap = reader.ReadSingle(),
            m_networkPaused = reader.ReadByte() // 47    
        };
    }
}
