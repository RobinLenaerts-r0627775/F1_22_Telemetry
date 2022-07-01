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
    }
}