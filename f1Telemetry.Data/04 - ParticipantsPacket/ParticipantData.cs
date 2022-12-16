namespace f1Telemetry.Data;
public class ParticipantData
{
    byte m_aiControlled; // Whether the vehicle is AI (1) or Human (0) controlled
    byte m_driverId; // Driver id - see appendix, 255 if network human
    byte m_networkId; // Network id – unique identifier for network players
    byte m_teamId; // Team id - see appendix
    byte m_myTeam; // My team flag – 1 = My Team, 0 = otherwise
    byte m_raceNumber; // Race number of the car
    byte m_nationality; // Nationality of the driver

    char[] m_name = new char[48]; // Name of participant in UTF-8 format – null terminated
    //TODO: figure out the null termination

    // Will be truncated with … (U+2026) if too long
    byte m_yourTelemetry; // The player's UDP setting, 0 = restricted, 1 = public

    public static ParticipantData FromArray(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        var s = new ParticipantData
        {
            m_aiControlled = reader.ReadByte(),
            m_driverId = reader.ReadByte(),
            m_networkId = reader.ReadByte(),
            m_teamId = reader.ReadByte(),
            m_myTeam = reader.ReadByte(),
            m_raceNumber = reader.ReadByte(),
            m_nationality = reader.ReadByte()
        };
        for (int i = 0; i < 48; i++)
        {
            s.m_name[i] = reader.ReadChar();
        }
        s.m_yourTelemetry = reader.ReadByte();
        return s;
    }
}