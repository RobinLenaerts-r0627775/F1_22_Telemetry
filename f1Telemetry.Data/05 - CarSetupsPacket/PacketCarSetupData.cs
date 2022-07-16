using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1Telemetry.Data
{
    public class PacketCarSetupData
    {
        PacketHeader m_header; // Header

        CarSetupData[] m_carSetups = new CarSetupData[22];

        public PacketCarSetupData(byte[] packet)
        {
            var reader = new BinaryReader(new MemoryStream(packet));
            var m_header = PacketHeader.FromArray(reader.ReadBytes(24));


            var bytes = reader.ReadBytes(56);
            for (int i = 0; i < 22; i++)
            {
                m_carSetups[i] = CarSetupData.FromArray(bytes);
            }
        }

    }
}