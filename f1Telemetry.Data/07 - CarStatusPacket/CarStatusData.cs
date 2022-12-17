using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var carStatusData = new CarStatusData();

        carStatusData.m_tractionControl = reader.ReadByte();
        carStatusData.m_antiLockBrakes = reader.ReadByte();
        carStatusData.m_fuelMix = reader.ReadByte();
        carStatusData.m_frontBrakeBias = reader.ReadByte();
        carStatusData.m_pitLimiterStatus = reader.ReadByte();
        carStatusData.m_fuelInTank = reader.ReadSingle();
        carStatusData.m_fuelCapacity = reader.ReadSingle();
        carStatusData.m_fuelRemainingLaps = reader.ReadSingle();
        carStatusData.m_maxRPM = reader.ReadUInt16();
        carStatusData.m_idleRPM = reader.ReadUInt16();
        carStatusData.m_maxGears = reader.ReadByte();
        carStatusData.m_drsAllowed = reader.ReadByte();
        carStatusData.m_drsActivationDistance = reader.ReadUInt16();
        carStatusData.m_actualTyreCompound = reader.ReadByte();
        carStatusData.m_visualTyreCompound = reader.ReadByte();
        carStatusData.m_tyresAgeLaps = reader.ReadByte();
        carStatusData.m_vehicleFiaFlags = reader.ReadSByte();
        carStatusData.m_ersStoreEnergy = reader.ReadSingle();
        carStatusData.m_ersDeployMode = reader.ReadByte();
        carStatusData.m_ersHarvestedThisLapMGUK = reader.ReadSingle();
        carStatusData.m_ersHarvestedThisLapMGUH = reader.ReadSingle();
        carStatusData.m_ersDeployedThisLap = reader.ReadSingle();
        carStatusData.m_networkPaused = reader.ReadByte(); // 47    

        return carStatusData;

    }

}
