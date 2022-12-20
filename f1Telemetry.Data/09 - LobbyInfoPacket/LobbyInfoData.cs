namespace f1Telemetry.Data;

public class LobbyInfoData
{
    byte m_aiControlled;            // Whether the vehicle is AI (1) or Human (0) controlled
    byte m_teamId;                  // Team id - see appendix (255 if no team currently selected)
    byte m_nationality;             // Nationality of the driver
    char[] m_name = new char[48];		// Name of participant in UTF-8 format – null terminated
                                         // Will be truncated with ... (U+2026) if too long
    byte m_carNumber;               // Car number of the player
    byte m_readyStatus;             // 0 = not ready, 1 = ready, 2 = spectating
    public static LobbyInfoData FromArray(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        return new LobbyInfoData
        {
            m_aiControlled = reader.ReadByte(),
            m_teamId = reader.ReadByte(),
            m_nationality = reader.ReadByte(),
            m_name = reader.ReadChars(48),
            m_carNumber = reader.ReadByte(),
            m_readyStatus = reader.ReadByte()
        };
    }
}