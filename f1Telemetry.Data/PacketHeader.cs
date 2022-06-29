namespace f1Telemetry.Data
{
    [Serializable]
    public class PacketHeader
    {
        public ushort m_packetFormat;            // 2022
        public sbyte m_gameMinorVersion;        // Game minor version - "1.XX"
        public sbyte m_gameMajorVersion;        // Game major version - "X.00"
        public sbyte m_packetVersion;           // Version of this packet type, all start from 1
        public sbyte m_packetId;                // Identifier for the packet type, see below
        public ulong m_sessionUID;              // Unique identifier for the session
        public float m_sessionTime;             // Session timestamp
        public uint m_frameIdentifier;         // Identifier for the frame the data was retrieved on
        public sbyte m_playerCarIndex;          // Index of player's car in the array
        public sbyte m_secondaryPlayerCarIndex; // Index of secondary player's car in the array (splitscreen)
                                                // -1 if no second player
        public static PacketHeader FromArray(byte[] bytes)
        {
            var reader = new BinaryReader(new MemoryStream(bytes));

            var s = new PacketHeader();

            s.m_packetFormat = reader.ReadUInt16();
            s.m_gameMajorVersion = reader.ReadSByte();
            s.m_gameMinorVersion = reader.ReadSByte();
            s.m_packetVersion = reader.ReadSByte();
            s.m_packetId = reader.ReadSByte();
            s.m_sessionUID = reader.ReadUInt64();
            s.m_sessionTime = reader.ReadSingle();
            s.m_frameIdentifier = reader.ReadUInt32();
            s.m_playerCarIndex = reader.ReadSByte();
            s.m_secondaryPlayerCarIndex = reader.ReadSByte();

            return s;
        }

        public override string ToString()
        {
            return "DataHeader: \n"
                + m_packetFormat + "\n"
                + m_gameMajorVersion + "\n"
                + m_gameMinorVersion + "\n"
                + m_packetVersion + "\n"
                + m_packetId + "\n"
                + m_sessionUID + "\n"
                + m_sessionTime + "\n"
                + m_frameIdentifier + "\n"
                + m_playerCarIndex + "\n"
                + m_secondaryPlayerCarIndex + "\n";
        }
    }
}