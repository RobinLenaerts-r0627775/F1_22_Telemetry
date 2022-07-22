using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1Telemetry.Data;

public class PacketParticipantsData
{
    PacketHeader m_header; // Header
    byte m_numActiveCars; // Number of active cars in the data – should match number of cars on HUD
    ParticipantData[] m_participants = new ParticipantData[22];

    public PacketParticipantsData(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        var m_header = PacketHeader.FromArray(reader.ReadBytes(24));

        m_numActiveCars = reader.ReadByte();
        var bytes = reader.ReadBytes(56);
        for (int i = 0; i < 22; i++)
        {
            m_participants[i] = ParticipantData.FromArray(bytes);
        }
    }
}