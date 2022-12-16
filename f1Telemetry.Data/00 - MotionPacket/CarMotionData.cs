namespace f1Telemetry.Data;
    /**
    * General Car Data
    * Size: 60 bytes
    **/

public class CarMotionData
{
    public float m_worldPositionX;           // World space X position
    public float m_worldPositionY;           // World space Y position
    public float m_worldPositionZ;           // World space Z position
    public float m_worldVelocityX;           // Velocity in world space X
    public float m_worldVelocityY;           // Velocity in world space Y
    public float m_worldVelocityZ;           // Velocity in world space Z
    public short m_worldForwardDirX;         // World space forward X direction (normalised)
    public short m_worldForwardDirY;         // World space forward Y direction (normalised)
    public short m_worldForwardDirZ;         // World space forward Z direction (normalised)
    public short m_worldRightDirX;           // World space right X direction (normalised)
    public short m_worldRightDirY;           // World space right Y direction (normalised)
    public short m_worldRightDirZ;           // World space right Z direction (normalised)
    public float m_gForceLateral;            // Lateral G-Force component
    public float m_gForceLongitudinal;       // Longitudinal G-Force component
    public float m_gForceVertical;           // Vertical G-Force component
    public float m_yaw;                      // Yaw angle in radians
    public float m_pitch;                    // Pitch angle in radians
    public float m_roll;                     // Roll angle in radians

    public static CarMotionData FromArray(byte[] bytes)
    {
        var reader = new BinaryReader(new MemoryStream(bytes));

        return new CarMotionData
        {
            m_worldPositionX = reader.ReadSingle(),
            m_worldPositionY = reader.ReadSingle(),
            m_worldPositionZ = reader.ReadSingle(),
            m_worldVelocityX = reader.ReadSingle(),
            m_worldVelocityY = reader.ReadSingle(),
            m_worldVelocityZ = reader.ReadSingle(),
            m_worldForwardDirX = reader.ReadInt16(),
            m_worldForwardDirY = reader.ReadInt16(),
            m_worldForwardDirZ = reader.ReadInt16(),
            m_worldRightDirX = reader.ReadInt16(),
            m_worldRightDirY = reader.ReadInt16(),
            m_worldRightDirZ = reader.ReadInt16(),
            m_gForceLateral = reader.ReadSingle(),
            m_gForceLongitudinal = reader.ReadSingle(),
            m_gForceVertical = reader.ReadSingle(),
            m_yaw = reader.ReadSingle(),
            m_pitch = reader.ReadSingle(),
            m_roll = reader.ReadSingle()
        };
    }
}
