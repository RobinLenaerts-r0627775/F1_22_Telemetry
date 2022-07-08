using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1Telemetry.Data
{
    public class CarTelemetryData
    {
        ushort m_speed;                    // Speed of car in kilometres per hour
        float m_throttle;                 // Amount of throttle applied (0.0 to 1.0)
        float m_steer;                    // Steering (-1.0 (full lock left) to 1.0 (full lock right))
        float m_brake;                    // Amount of brake applied (0.0 to 1.0)
        byte m_clutch;                   // Amount of clutch applied (0 to 100)
        sbyte m_gear;                     // Gear selected (1-8, N=0, R=-1)
        ushort m_engineRPM;                // Engine RPM
        byte m_drs;                      // 0 = off, 1 = on
        byte m_revLightsPercent;         // Rev lights indicator (percentage)
        ushort m_revLightsBitValue;        // Rev lights (bit 0 = leftmost LED, bit 14 = rightmost LED)
        ushort[] m_brakesTemperature = new ushort[4];     // Brakes temperature (celsius)
        byte[] m_tyresSurfaceTemperature = new byte[4]; // Tyres surface temperature (celsius)
        byte[] m_tyresInnerTemperature = new byte[4]; // Tyres inner temperature (celsius)
        ushort m_engineTemperature;        // Engine temperature (celsius)
        float[] m_tyresPressure = new float[4];         // Tyres pressure (PSI)
        byte[] m_surfaceType = new byte[4];           // Driving surface, see appendices

    }
}
