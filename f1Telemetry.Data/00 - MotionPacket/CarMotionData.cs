namespace f1Telemetry.Data;
    /**
    * General Car Data
    * Size: 60 bytes
    **/

public class CarMotionData
{
    public float WorldPositionX { get; set; }
    public float WorldPositionY { get; set; }
    public float WorldPositionZ { get; set; }
    public float WorldVelocityX { get; set; }
    public float WorldVelocityY { get; set; }
    public float WorldVelocityZ { get; set; }
    public short WorldForwardDirX { get; set; }
    public short WorldForwardDirY { get; set; }
    public short WorldForwardDirZ { get; set; }
    public short WorldRightDirX { get; set; }
    public short WorldRightDirY { get; set; }
    public short WorldRightDirZ { get; set; }
    public float GForceLateral { get; set; }
    public float GForceLongitudinal { get; set; }
    public float GForceVertical { get; set; }
    public float Yaw { get; set; }
    public float Pitch { get; set; }
    public float Roll { get; set; }

    public static CarMotionData FromArray(byte[] data)
    {
        var result = new CarMotionData();
        using (var memoryStream = new MemoryStream(data))
        {
            using var binaryReader = new BinaryReader(memoryStream);
            result.WorldPositionX = binaryReader.ReadSingle();
            result.WorldPositionY = binaryReader.ReadSingle();
            result.WorldPositionZ = binaryReader.ReadSingle();
            result.WorldVelocityX = binaryReader.ReadSingle();
            result.WorldVelocityY = binaryReader.ReadSingle();
            result.WorldVelocityZ = binaryReader.ReadSingle();
            result.WorldForwardDirX = binaryReader.ReadInt16();
            result.WorldForwardDirY = binaryReader.ReadInt16();
            result.WorldForwardDirZ = binaryReader.ReadInt16();
            result.WorldRightDirX = binaryReader.ReadInt16();
            result.WorldRightDirY = binaryReader.ReadInt16();
            result.WorldRightDirZ = binaryReader.ReadInt16();
            result.GForceLateral = binaryReader.ReadSingle();
            result.GForceLongitudinal = binaryReader.ReadSingle();
            result.GForceVertical = binaryReader.ReadSingle();
            result.Yaw = binaryReader.ReadSingle();
            result.Pitch = binaryReader.ReadSingle();
            result.Roll = binaryReader.ReadSingle();
        }
        return result;
    }
}