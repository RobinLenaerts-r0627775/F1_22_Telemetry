namespace f1Telemetry.Data;
public class PacketParticipantsData
{
    readonly PacketHeader m_header; // Header
    readonly byte m_numActiveCars; // Number of active cars in the data – should match number of cars on HUD
    readonly ParticipantData[] m_participants = new ParticipantData[22];

    public PacketParticipantsData(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        m_header = PacketHeader.FromArray(reader.ReadBytes(24));

        m_numActiveCars = reader.ReadByte();
        for (int i = 0; i < 22; i++)
        {
            m_participants[i] = ParticipantData.FromArray(reader.ReadBytes(56));
        }
    }
}