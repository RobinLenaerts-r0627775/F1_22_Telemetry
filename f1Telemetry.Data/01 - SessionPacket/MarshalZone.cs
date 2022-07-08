using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1Telemetry.Data
{
    public class MarshalZone
    {
        float m_zoneStart; // Fraction (0..1) of way through the lap the marshal zone starts
        SByte m_zoneFlag; // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red


        public static MarshalZone FromArray(byte[] bytes)
        {
            var reader = new BinaryReader(new MemoryStream(bytes));

            var s = new MarshalZone();

            s.m_zoneStart = reader.ReadSingle();
            s.m_zoneFlag = reader.ReadSByte();

            return s;
        }
    }
}