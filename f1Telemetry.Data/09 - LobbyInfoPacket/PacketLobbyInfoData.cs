namespace f1Telemetry.Data;

public class PacketLobbyInfoData
{
    readonly PacketHeader m_header; // Header
    readonly byte m_numPlayers; // Number of players in the lobby data
    readonly LobbyInfoData[] m_lobbyPlayers = new LobbyInfoData[22];

    public PacketLobbyInfoData(byte[] packet){
        var reader = new BinaryReader(new MemoryStream(packet));
        m_header = PacketHeader.FromArray(reader.ReadBytes(24));

        m_numPlayers = reader.ReadByte();
        for (int i = 0; i < 22; i++)
        {
            m_lobbyPlayers[i] = LobbyInfoData.FromArray(reader.ReadBytes(53));
        }
    }
}