namespace f1Telemetry.Test;

public class PacketTests
{
    private byte[] headerData = new byte[] 
    {
        0xE6, 0x07, // m_packetFormat = 2022
        0x08,       // m_gameMajorVersion = 8
        0x05,       // m_gameMinorVersion = 5
        0x01,       // m_packetVersion = 1
        0x02,       // m_packetId = 2
        0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, // m_sessionUID = 1
        0x00, 0x00, 0x48, 0x42, // m_sessionTime = 50.0f
        0x01, 0x00, 0x00, 0x00, // m_frameIdentifier = 1
        0x03,       // m_playerCarIndex = 3
        0xFF        // m_secondaryPlayerCarIndex = -1
    };

    public byte[] HeaderData { get => headerData; set => headerData = value; }

    [Fact]
    public void HeaderTest()
    {
        var header = PacketHeader.FromArray(HeaderData);
        Console.WriteLine(header);
        Assert.Equal(2022, header.PacketFormat);    
        Assert.Equal(8, header.GameMajorVersion);
        Assert.Equal(5, header.GameMinorVersion);
        Assert.Equal(1, header.PacketVersion);
        Assert.Equal(2, header.PacketId);
        Assert.Equal((ulong)1, header.SessionUID);
        Assert.Equal(50.0f, header.SessionTime);
        Assert.Equal((uint)1, header.FrameIdentifier);
        Assert.Equal(3, header.PlayerCarIndex);
        Assert.Equal(-1, header.SecondaryPlayerCarIndex);
    }

    [Fact]
    public void CarMotionTest()
    {
        byte[] exampleData = {
            0x3f, 0x00, 0x00, 0x05, // WorldPositionX
            0x02, 0x00, 0x00, 0x00, // WorldPositionY
            0x03, 0x00, 0x00, 0x00, // WorldPositionZ
            0x05, 0x00, 0x00, 0x00, // WorldVelocityX
            0x06, 0x00, 0x00, 0x00, // WorldVelocityY
            0x07, 0x00, 0x00, 0x00, // WorldVelocityZ
            0x0a, 0x00,             // WorldForwardDirX
            0x7f, 0x01,             // WorldForwardDirY
            0x7f, 0x02,             // WorldForwardDirZ
            0x7f, 0x03,             // WorldRightDirX
            0x7f, 0x04,             // WorldRightDirY
            0x7f, 0x05,             // WorldRightDirZ
            0x01, 0x00, 0x00, 0x00, // GForceLateral
            0x01, 0x00, 0x00, 0x00, // GForceLongitudinal
            0x01, 0x00, 0x00, 0x00, // GForceVertical
            0x01, 0x00, 0x00, 0x00, // Yaw
            0x01, 0x00, 0x00, 0x00, // Pitch
            0x01, 0x00, 0x00, 0x00  // Roll
        };
        var carMotion = CarMotionData.FromArray(exampleData);

        Assert.Equal(1.0f, carMotion.WorldPositionX);
        Assert.Equal(2.0f, carMotion.WorldPositionY);
        Assert.Equal(3.0f, carMotion.WorldPositionZ);
        Assert.Equal(5.0f, carMotion.WorldVelocityX);
        Assert.Equal(6.0f, carMotion.WorldVelocityY);
        Assert.Equal(7.0f, carMotion.WorldVelocityZ);
        Assert.Equal(10.0f, carMotion.WorldForwardDirX);
        Assert.Equal(2.0f, carMotion.WorldForwardDirY);
        Assert.Equal(3.0f, carMotion.WorldForwardDirZ);
        Assert.Equal(4.0f, carMotion.WorldRightDirX);
        Assert.Equal(5.0f, carMotion.WorldRightDirY);
        Assert.Equal(6.0f, carMotion.WorldRightDirZ);
        Assert.Equal(1.0f, carMotion.GForceLateral);
        Assert.Equal(2.0f, carMotion.GForceLongitudinal);
        Assert.Equal(3.0f, carMotion.GForceVertical);
        Assert.Equal(4.0f, carMotion.Yaw);
        Assert.Equal(5.0f, carMotion.Pitch);
        Assert.Equal(6.0f, carMotion.Roll);
    }
}