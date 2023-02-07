using System.ComponentModel.DataAnnotations;

namespace f1Telemetry.Data;

/**
 * This part comes with every packet.
 * Size: 24 Bytes
 *
 **/
[Serializable]
public class PacketHeader
{
    [Key]
    public int Id { get; set; }
    public ushort PacketFormat {get; set;}            // 2022
    public sbyte GameMinorVersion {get; set;}        // Game minor version - "1.XX"
    public sbyte GameMajorVersion {get; set;}       // Game major version - "X.00"
    public sbyte PacketVersion {get; set;}           // Version of this packet type, all start from 1
    public sbyte PacketId {get; set;}                // Identifier for the packet type
    public ulong SessionUID {get; set;}              // Unique identifier for the session
    public float SessionTime {get; set;}             // Session timestamp
    public uint FrameIdentifier {get; set;}         // Identifier for the frame the data was retrieved on
    public sbyte PlayerCarIndex {get; set;}          // Index of player's car in the array
    public sbyte SecondaryPlayerCarIndex {get; set;} // Index of secondary player's car in the array (splitscreen)
                                            // -1 if no second player
    public static PacketHeader FromArray(byte[] bytes)
    {
        var reader = new BinaryReader(new MemoryStream(bytes));

        return new PacketHeader
        {
            PacketFormat = reader.ReadUInt16(),
            GameMajorVersion = reader.ReadSByte(),
            GameMinorVersion = reader.ReadSByte(),
            PacketVersion = reader.ReadSByte(),
            PacketId = reader.ReadSByte(),
            SessionUID = reader.ReadUInt64(),
            SessionTime = reader.ReadSingle(),
            FrameIdentifier = reader.ReadUInt32(),
            PlayerCarIndex = reader.ReadSByte(),
            SecondaryPlayerCarIndex = reader.ReadSByte()
        };
    }

    public override string ToString()
    {
        return "DataHeader: \n"
            + PacketFormat + "\n"
            + GameMajorVersion + "\n"
            + GameMinorVersion + "\n"
            + PacketVersion + "\n"
            + PacketId + "\n"
            + SessionUID + "\n"
            + SessionTime + "\n"
            + FrameIdentifier + "\n"
            + PlayerCarIndex + "\n"
            + SecondaryPlayerCarIndex + "\n";
    }
}