using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using f1Telemetry.Data;

namespace f1Telemetry.UI.Services;

public class UDPService
{
    public PacketMotionData MotionPacket { get; set; }
    public PacketSessionData SessionPacket {get; set;}
    public PacketLapData LapDataPacket { get; set; }
    public PacketEventData EventDataPacket { get; set; }
    public PacketParticipantsData ParticipantsPacket { get; set; }
    public PacketCarSetupData CarSetupsPacket { get; set; }
    public PacketCarTelemetryData CarTelemetryPacket { get; set; }
    public PacketCarSetupData CarStatusPacket { get; set; }
    public PacketFinalClassificationData FinalClassificationPacket { get; set; }
    public PacketLobbyInfoData LobbyInfoPacket { get; set; }
    public PacketCarDamageData CarDamagePacket { get; set; }
    public PacketSessionData SessionHistoryPacket { get; set; }

    public static int Test { get; set; }

    public static void Count()
    {
        Test++;
    }

    public async void Listen()
    {
        UdpClient? client;
        try
        {
            client = new UdpClient(20777);
            Console.WriteLine("Listening...");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return;
        }

        while (true)
        {
            IPEndPoint server = new(IPAddress.Any, 20777);
            byte[] packet = client.Receive(ref server);
            var header = PacketHeader.FromArray(packet.SubArray(0, 24));
            switch (header.m_packetId)
            {
                case 0:
                    MotionPacket = new PacketMotionData(packet);
                    break;
                case 1:
                    SessionPacket = new PacketSessionData(packet);
                    break;
                case 2:
                    LapDataPacket = new PacketLapData(packet);
                    break;
                case 3:
                    EventDataPacket = new PacketEventData(packet);
                    break;
                case 4:
                    var participantsPacket = new PacketParticipantsData(packet);
                    break;
                case 5:
                    var carSetupsPacket = new PacketCarSetupData(packet);
                    break;
                case 6:
                    var carTelemetryPacket = new PacketCarTelemetryData(packet);
                    break;
                case 7:
                    var carStatusPacket = new PacketCarSetupData(packet);
                    break;
                case 8:
                    var finalClassificationPacket = new PacketFinalClassificationData(packet);
                    break;
                case 9:
                    var lobbyInfoPacket = new PacketLobbyInfoData(packet);
                    break;
                case 10:
                    var carDamagePacket = new PacketCarDamageData(packet);
                    break;
                case 11:
                    var sessionHistoryPacket = new PacketSessionData(packet);
                    break;
            }
        }
    }
}
