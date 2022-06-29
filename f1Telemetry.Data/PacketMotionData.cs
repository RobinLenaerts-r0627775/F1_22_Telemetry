using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1Telemetry.Data
{
    public class PacketMotionData
    {
        public PacketHeader m_header;                  // Header
        public CarMotionData[] m_carMotionData;      // Data for all cars on track
        // Extra player car ONLY data
        public float[] m_suspensionPosition;       // Note: All wheel arrays have the following order:
        public float[] m_suspensionVelocity;       // RL, RR, FL, FR
        public float[] m_suspensionAcceleration;  // RL, RR, FL, FR
        public float[] m_wheelSpeed;              // Speed of each wheel
        public float[] m_wheelSlip;                // Slip ratio for each wheel
        public float m_localVelocityX;             // Velocity in local space
        public float m_localVelocityY;             // Velocity in local space
        public float m_localVelocityZ;             // Velocity in local space
        public float m_angularVelocityX;       // Angular velocity x-component
        public float m_angularVelocityY;            // Angular velocity y-component
        public float m_angularVelocityZ;            // Angular velocity z-component
        public float m_angularAccelerationX;        // Angular velocity x-component
        public float m_angularAccelerationY;   // Angular velocity y-component
        public float m_angularAccelerationZ;        // Angular velocity z-component
        public float m_frontWheelsAngle;            // Current front wheels angle in radians

        public static PacketMotionData FromArray(byte[] bytes)
        {
            var reader = new BinaryReader(new MemoryStream(bytes));

            var s = new PacketMotionData();

            s.m_packetFormat = reader.ReadUInt16();
            s.m_gameMajorVersion = reader.ReadSByte();
            s.m_gameMinorVersion = reader.ReadSByte();
            s.m_packetVersion = reader.ReadSByte();
            s.m_packetId = reader.ReadSByte();
            s.m_sessionUID = reader.ReadUInt64();
            s.m_sessionTime = reader.ReadSingle();
            s.m_frameIdentifier = reader.ReadUInt32();
            s.m_playerCarIndex = reader.ReadSByte();
            s.m_secondaryPlayerCarIndex = reader.ReadSByte();

            return s;
        }
    }
}
