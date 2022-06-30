using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1Telemetry.Data
{
    /**
     * Car motion Packet
     * Size: 1464 bytes
     **/
    public class PacketMotionData
    {
        public PacketHeader m_header;                  // Header //24 bytes
        public CarMotionData[] m_carMotionData = new CarMotionData[22]; //22      // Data for all cars on track //60bytes each

        // Extra player car ONLY data //Size: 120
        public float[] m_suspensionPosition = new float[4];    //4    // Note: All wheel arrays have the following order: 
        public float[] m_suspensionVelocity = new float[4];    //4    // RL, RR, FL, FR
        public float[] m_suspensionAcceleration = new float[4];//4  // RL, RR, FL, FR
        public float[] m_wheelSpeed = new float[4];            //4  // Speed of each wheel4
        public float[] m_wheelSlip = new float[4];             //4   // Slip ratio for each wheel
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

        public PacketMotionData (byte[] bytes)
        {
            var reader = new BinaryReader(new MemoryStream(bytes));
            var m_header = PacketHeader.FromArray(reader.ReadBytes(24));

            for (int i = 0; i < 22; i++)
            {
                var temp = CarMotionData.FromArray(reader.ReadBytes(60));
                m_carMotionData[i] = temp;
            }

            for (int i = 0; i < 4; i++)
            {
                m_suspensionPosition[i] = reader.ReadSingle();
            }
            for(int i = 0; i < 4; i++)
            {
                m_suspensionVelocity[i] = reader.ReadSingle();
            }
            for(int i = 0; i < 4; i++)
            {
                m_suspensionAcceleration[i] = reader.ReadSingle();
            }
            for(int i = 0; i < 4; i++)
            {
                m_wheelSpeed[i] = reader.ReadSingle();
            }
            for(int i = 0; i < 4; i++)
            {
                m_wheelSlip[i] = reader.ReadSingle();
            }
            m_localVelocityX = reader.ReadSingle();
            m_localVelocityY = reader.ReadSingle();
            m_localVelocityZ = reader.ReadSingle();
            m_angularVelocityX = reader.ReadSingle();
            m_angularVelocityY = reader.ReadSingle();
            m_angularVelocityZ = reader.ReadSingle();
            m_angularAccelerationX = reader.ReadSingle();
            m_angularAccelerationY = reader.ReadSingle();
            m_angularAccelerationZ = reader.ReadSingle();
            m_frontWheelsAngle = reader.ReadSingle();

            Console.WriteLine("reddit");
;        }
    }
}
