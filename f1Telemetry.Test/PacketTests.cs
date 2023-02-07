namespace f1Telemetry.Test;

public class PacketTests
{
    [Fact]
    public void HeaderTest()
    {
        byte[] data = new byte[] {
            0x06, 0x76, // m_packetFormat = 2022
            0x08,       // m_gameMajorVersion = 8
            0x05,       // m_gameMinorVersion = 5
            0x01,       // m_packetVersion = 1
            0x02,       // m_packetId = 2
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, // m_sessionUID = 1
            0x49, 0x96, 0x2C, 0x41, // m_sessionTime = 50.0f
            0x00, 0x00, 0x00, 0x01, // m_frameIdentifier = 1
            0x03,       // m_playerCarIndex = 3
            0xFF        // m_secondaryPlayerCarIndex = 255
        };

        var header = PacketHeader.FromArray(data);
        Assert.Equal(2022, header.m_packetFormat);    
        Assert.Equal(8, header.m_gameMajorVersion);
        Assert.Equal(5, header.m_gameMinorVersion);
        Assert.Equal(1, header.m_packetVersion);
        Assert.Equal(2, header.m_packetId);
        Assert.Equal(1, header.m_sessionUID);
        Assert.Equal(50.0f, header.m_sessionTime);
        Assert.Equal(1, header.m_frameIdentifier);
        Assert.Equal(3, header.m_playerCarIndex);
        Assert.Equal(255, header.m_secondaryPlayerCarIndex);
    }
}