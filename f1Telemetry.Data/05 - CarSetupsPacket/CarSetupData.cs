using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1Telemetry.Data
{
    public class CarSetupData
    {
        byte m_frontWing;                // Front wing aero
        byte m_rearWing;                 // Rear wing aero
        byte m_onThrottle;               // Differential adjustment on throttle (percentage)
        byte m_offThrottle;              // Differential adjustment off throttle (percentage)
        float m_frontCamber;              // Front camber angle (suspension geometry)
        float m_rearCamber;               // Rear camber angle (suspension geometry)
        float m_frontToe;                 // Front toe angle (suspension geometry)
        float m_rearToe;                  // Rear toe angle (suspension geometry)
        byte m_frontSuspension;          // Front suspension
        byte m_rearSuspension;           // Rear suspension
        byte m_frontAntiRollBar;         // Front anti-roll bar
        byte m_rearAntiRollBar;          // Front anti-roll bar
        byte m_frontSuspensionHeight;    // Front ride height
        byte m_rearSuspensionHeight;     // Rear ride height
        byte m_brakePressure;            // Brake pressure (percentage)
        byte m_brakeBias;                // Brake bias (percentage)
        float m_rearLeftTyrePressure;     // Rear left tyre pressure (PSI)
        float m_rearRightTyrePressure;    // Rear right tyre pressure (PSI)
        float m_frontLeftTyrePressure;    // Front left tyre pressure (PSI)
        float m_frontRightTyrePressure;   // Front right tyre pressure (PSI)
        byte m_ballast;                  // Ballast
        float m_fuelLoad;                 // Fuel load


        public static CarSetupData FromArray(byte[] packet)
        {
            var reader = new BinaryReader(new MemoryStream(packet));
            var s = new CarSetupData();

            s.m_frontWing = reader.ReadByte();
            s.m_rearWing = reader.ReadByte();
            s.m_onThrottle = reader.ReadByte();
            s.m_offThrottle = reader.ReadByte();
            s.m_frontCamber = reader.ReadSingle();
            s.m_rearCamber = reader.ReadSingle();
            s.m_frontToe = reader.ReadSingle();
            s.m_rearToe = reader.ReadSingle();
            s.m_frontSuspension = reader.ReadByte();
            s.m_rearSuspension = reader.ReadByte();
            s.m_frontAntiRollBar = reader.ReadByte();
            s.m_rearAntiRollBar = reader.ReadByte();
            s.m_frontSuspensionHeight = reader.ReadByte();
            s.m_rearSuspensionHeight = reader.ReadByte();
            s.m_brakePressure = reader.ReadByte();
            s.m_brakeBias = reader.ReadByte();
            s.m_rearLeftTyrePressure = reader.ReadSingle();
            s.m_rearRightTyrePressure = reader.ReadSingle();
            s.m_frontLeftTyrePressure = reader.ReadSingle();
            s.m_frontRightTyrePressure = reader.ReadSingle();
            s.m_ballast = reader.ReadByte();
            s.m_fuelLoad = reader.ReadSingle();


            return s;
        }
    }
}