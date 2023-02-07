using System.ComponentModel.DataAnnotations;

namespace f1Telemetry.Data;
/**
    * Car motion Packet
    * Size: 1464 bytes
    **/
public class PacketMotionData
{
    [Key]
    public int Id { get; set; }
    public PacketHeader Header { get; set; }                  // Header //24 bytes
    public CarMotionData[] CarMotionDataArray { get; set; } = new CarMotionData[22]; //22      // Data for all cars on track //60bytes each

    // Extra player car ONLY data //Size: 120
    public float[] SuspensionPosition { get; set; } = new float[4];    //4    // Note: All wheel arrays have the following order: 
    public float[] SuspensionVelocity { get; set; } = new float[4];    //4    // RL, RR, FL, FR
    public float[] SuspensionAcceleration { get; set; } = new float[4];//4  // RL, RR, FL, FR
    public float[] WheelSpeed { get; set; } = new float[4];            //4  // Speed of each wheel4
    public float[] WheelSlip { get; set; } = new float[4];             //4   // Slip ratio for each wheel
    public float LocalVelocityX { get; set; }             // Velocity in local space
    public float LocalVelocityY { get; set; }             // Velocity in local space
    public float LocalVelocityZ { get; set; }             // Velocity in local space
    public float AngularVelocityX { get; set; }       // Angular velocity x-component
    public float AngularVelocityY { get; set; }            // Angular velocity y-component
    public float AngularVelocityZ { get; set; }            // Angular velocity z-component
    public float AngularAccelerationX { get; set; }        // Angular velocity x-component
    public float AngularAccelerationY { get; set; }   // Angular velocity y-component
    public float AngularAccelerationZ { get; set; }        // Angular velocity z-component
    public float FrontWheelsAngle { get; set; }            // Current front wheels angle in radians

    public PacketMotionData(){}
    public PacketMotionData (byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        Header = PacketHeader.FromArray(reader.ReadBytes(24));

        for (int i = 0; i < 22; i++)
        {
            CarMotionDataArray[i] = CarMotionData.FromArray(reader.ReadBytes(60));
        }

        for (int i = 0; i < 4; i++)
        {
            SuspensionPosition[i] = reader.ReadSingle();
        }
        for(int i = 0; i < 4; i++)
        {
            SuspensionVelocity[i] = reader.ReadSingle();
        }
        for(int i = 0; i < 4; i++)
        {
            SuspensionAcceleration[i] = reader.ReadSingle();
        }
        for(int i = 0; i < 4; i++)
        {
            WheelSpeed[i] = reader.ReadSingle();
        }
        for(int i = 0; i < 4; i++)
        {
            WheelSlip[i] = reader.ReadSingle();
        }
        LocalVelocityX = reader.ReadSingle();
        LocalVelocityY = reader.ReadSingle();
        LocalVelocityZ = reader.ReadSingle();
        AngularVelocityX = reader.ReadSingle();
        AngularVelocityY = reader.ReadSingle();
        AngularVelocityZ = reader.ReadSingle();
        AngularAccelerationX = reader.ReadSingle();
        AngularAccelerationY = reader.ReadSingle();
        AngularAccelerationZ = reader.ReadSingle();
        FrontWheelsAngle = reader.ReadSingle();
    }
}
