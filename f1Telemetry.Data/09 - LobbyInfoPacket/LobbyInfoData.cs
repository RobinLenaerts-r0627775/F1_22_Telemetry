namespace f1Telemetry.Data;

public class LobbyInfoData
{
    sbyte m_aiControlled;            // Whether the vehicle is AI (1) or Human (0) controlled
    sbyte m_teamId;                  // Team id - see appendix (255 if no team currently selected)
    sbyte m_nationality;             // Nationality of the driver
    char[] m_name = new char[48];		// Name of participant in UTF-8 format – null terminated
                                         // Will be truncated with ... (U+2026) if too long
    sbyte m_carNumber;               // Car number of the player
    sbyte m_readyStatus;             // 0 = not ready, 1 = ready, 2 = spectating
    public static LobbyInfoData FromArray(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        return new LobbyInfoData
        {
            m_aiControlled = reader.ReadSByte(),
            m_teamId = reader.ReadSByte(),
            m_nationality = reader.ReadSByte(),
            m_name = reader.ReadChars(48),
            m_carNumber = reader.ReadSByte(),
            m_readyStatus = reader.ReadSByte()
        };
    }
}