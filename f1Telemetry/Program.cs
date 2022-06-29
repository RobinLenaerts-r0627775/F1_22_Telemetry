// See https://aka.ms/new-console-template for more information

using f1Telemetry.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


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
    Console.WriteLine(header.m_packetId);
    switch (header.m_packetId)
    {
        case 0:

            break;
    }

}
public static class Extensions
{ 
    public static T[] SubArray<T>(this T[] array, int offset, int length)
    {
        T[] result = new T[length];
        Array.Copy(array, offset, result, 0, length);
        return result;
    }
}