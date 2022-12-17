using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using f1Telemetry.Data;

namespace f1Telemetry.UI.Services;

public class UDPService
{
    public PacketMotionData motionPacket;
    public PacketSessionData sessionPacket;
    public PacketLapData lapDataPacket;

    public static int Test { get; set; }

    public static void Count()
    {
        Test++;
    }
    public async void Listen()
    {
        UdpClient client = null;
        try
        {
            client = new UdpClient(20777);
            Console.WriteLine("Listening...");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        while (true)
        {
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 20777);
            byte[] packet = client.Receive(ref server);
            var header = PacketHeader.FromArray(packet.SubArray(0, 24));
            switch (header.m_packetId)
            {
                case 0:
                    motionPacket = new PacketMotionData(packet);
                    break;
                case 1:
                    sessionPacket = new PacketSessionData(packet);
                    break;
                case 2:
                    lapDataPacket = new PacketLapData(packet);
                    break;
                /*case 3:
                    var eventPacket = new PacketSessionData(packet);
                    break;
                case 4:
                    var participantsPacket = new PacketSessionData(packet);
                    break;
                case 5:
                    var carSetupsPacket = new PacketSessionData(packet);
                    break;
                case 6:
                    var carTelemetryPacket = new PacketSessionData(packet);
                    break;
                case 7:
                    var carStatusPacket = new PacketSessionData(packet);
                    break;
                case 8:
                    var finalClassificationPacket = new PacketSessionData(packet);
                    break;
                case 9:
                    var lobbyInfoPacket = new PacketSessionData(packet);
                    break;
                case 10:
                    var carDamagePacket = new PacketSessionData(packet);
                    break;
                case 11:
                    var sessionHistoryPacket = new PacketSessionData(packet);
                    break;*/
            }
        }
    }
}
